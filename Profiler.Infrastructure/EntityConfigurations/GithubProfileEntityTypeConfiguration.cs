using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profiler.Domain.AggregatesModel;

namespace Profiler.Infrastructure.EntityConfigurations
{
    public class GithubProfileEntityTypeConfiguration : IEntityTypeConfiguration<GithubProfile>
    {
        public void Configure(EntityTypeBuilder<GithubProfile> builder)
        {
            builder.ToTable("githubprofiles", ProfileContext.DefaultSchema);
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).IsRequired();
            builder.Property(cr => cr.GithubAccount).IsRequired();
            builder.HasIndex(cr => cr.Name);
            builder.HasIndex(cr => cr.Email);
        }
    }
}