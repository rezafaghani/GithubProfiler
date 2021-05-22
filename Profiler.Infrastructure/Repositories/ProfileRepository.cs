using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profiler.Domain.AggregatesModel;
using Profiler.Domain.SeedWork;

namespace Profiler.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository 
        
    {
        private readonly ProfileContext _context;

        public ProfileRepository(ProfileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public GithubProfile Add(GithubProfile entity, long createdBy = 0)
        {
            entity.SetCreateDateTime();
            return _context.Set<GithubProfile>()
                .Add(entity)
                .Entity;
        }

        public async Task AddRange(List<GithubProfile> entity)
        {
            await _context.Set<GithubProfile>().AddRangeAsync(entity);
        }

        public GithubProfile Update(GithubProfile entity)
        {
            entity.SetUpdateDateTime();
            return _context.Set<GithubProfile>()
                .Update(entity)
                .Entity;
        }

        public GithubProfile Delete(GithubProfile entity)
        {
            entity.SetDeleteDateTime();
            entity.SetDeleted();
            return _context.Set<GithubProfile>()
                .Update(entity)
                .Entity;
        }

      
     
        public async Task<GithubProfile> GetAsync(long id)
        {
            var entity = await _context
                .Set<GithubProfile>()
                .FirstOrDefaultAsync(o => o.Id == id);
            if (entity == null)
            {
                entity = _context
                    .Set<GithubProfile>()
                    .Local
                    .FirstOrDefault(o => o.Id == id);
            }
            if (entity != null)
            {
                await _context.Entry(entity).ReloadAsync();
                   
            }

            return entity;
        }

     

        public async Task<GithubProfile> GetByEmail(string email)
        {
            var entity = await _context
                .Set<GithubProfile>()
                .FirstOrDefaultAsync(o => o.Email.ToLower() == email.ToLower());

            return entity;
        }
    }
}