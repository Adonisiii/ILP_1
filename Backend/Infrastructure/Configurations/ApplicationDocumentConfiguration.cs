using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class ApplicationDocumentConfiguration : IEntityTypeConfiguration<ApplicationDocument>
    {
        public void Configure(EntityTypeBuilder<ApplicationDocument> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApplicationRequest)
                .WithMany(x => x.ApplicationDocuments)
                .HasForeignKey(x => x.ApplicationRequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
