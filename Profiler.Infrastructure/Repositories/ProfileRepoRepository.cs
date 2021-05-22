using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profiler.Domain.AggregatesModel;
using Profiler.Domain.SeedWork;

namespace Profiler.Infrastructure.Repositories
{
    public class ProfileRepoRepository : IProfileRepoRepository
    {
        private readonly ProfileContext _context;


        public ProfileRepoRepository(ProfileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public ProfileRepo Add(ProfileRepo entity, long createdBy = 0)
        {
            entity.SetCreateDateTime();
            return _context.Set<ProfileRepo>()
                .Add(entity)
                .Entity;
        }

        public async Task AddRange(List<ProfileRepo> entity)
        {
            await _context.Set<ProfileRepo>().AddRangeAsync(entity);
        }

        public ProfileRepo Update(ProfileRepo entity)
        {
            entity.SetUpdateDateTime();
            return _context.Set<ProfileRepo>()
                .Update(entity)
                .Entity;
        }

        public ProfileRepo Delete(ProfileRepo entity)
        {
            entity.SetDeleteDateTime();
            entity.SetDeleted();
            return _context.Set<ProfileRepo>()
                .Update(entity)
                .Entity;
        }

        public async Task<ProfileRepo> GetAsync(long id)
        {
            var entity = await _context
                .Set<ProfileRepo>()
                .FirstOrDefaultAsync(o => o.Id == id);
            if (entity == null)
            {
                entity = _context
                    .Set<ProfileRepo>()
                    .Local
                    .FirstOrDefault(o => o.Id == id);
            }

            if (entity != null)
            {
                await _context.Entry(entity).ReloadAsync();
            }

            return entity;
        }

        public async Task<List<ProfileRepo>> GetByProfileIdAsync(long id)
        {
            var entity = await _context
                .Set<ProfileRepo>()
                .Where(o => o.GithubProfileId == id).ToListAsync();
           
            return entity;
        }
    }
}