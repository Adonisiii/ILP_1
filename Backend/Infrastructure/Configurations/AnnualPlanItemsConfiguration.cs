using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class AnnualPlanItemsConfiguration : IEntityTypeConfiguration<AnnualPlanItems>
    {
        public void Configure(EntityTypeBuilder<AnnualPlanItems> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AnnualPlan)
                .WithMany(x => x.AnnualPlanItems)
                .HasForeignKey(x => x.AnnualPlanId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Quantity)
                .HasPrecision(18, 2);
        }
    }
}