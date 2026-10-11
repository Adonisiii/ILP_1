using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class AnnualPlanConfiguration : IEntityTypeConfiguration<AnnualPlan>
    {
        public void Configure(EntityTypeBuilder<AnnualPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApplicationRequest)
                .WithOne(x => x.AnnualPlan)
                .HasForeignKey<AnnualPlan>(x => x.ApplicationRequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}