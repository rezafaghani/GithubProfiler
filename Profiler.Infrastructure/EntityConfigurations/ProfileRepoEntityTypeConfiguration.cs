using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profiler.Domain.AggregatesModel;

namespace Profiler.Infrastructure.EntityConfigurations
{
    public class ProfileRepoEntityTypeConfiguration : IEntityTypeConfiguration<ProfileRepo>
    {
        public void Configure(EntityTypeBuilder<ProfileRepo> builder)
        {
            builder.ToTable("profilerepos", ProfileContext.DefaultSchema);
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).IsRequired();
            builder.HasIndex(cr => cr.Name);
            builder.HasOne(cr => cr.GithubProfile)
                .WithMany(cr => cr.ProfileRepos)
                .HasForeignKey(cr => cr.GithubProfileId);
        }
    }
}