using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApplicationRequest)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.ApplicationRequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}