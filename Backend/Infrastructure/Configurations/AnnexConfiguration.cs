using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class AnnexConfiguration : IEntityTypeConfiguration<Annex>
    {
        public void Configure(EntityTypeBuilder<Annex> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApplicationRequest)
                .WithMany(x => x.Annexes)
                .HasForeignKey(x => x.ApplicationRequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
