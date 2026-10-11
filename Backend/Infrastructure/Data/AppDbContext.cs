using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ApplicationRequest> ApplicationRequests { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        public DbSet<AnnualPlan> AnnualPlans { get; set; }
        public DbSet<AnnualPlanItems> AnnualPlanItems { get; set; }
        public DbSet<Annex> Annexes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            ConfigureAudit<ApplicationRequest>(modelBuilder);
            ConfigureAudit<Activity>(modelBuilder);
            ConfigureAudit<ApplicationDocument>(modelBuilder);
            ConfigureAudit<AnnualPlan>(modelBuilder);
            ConfigureAudit<AnnualPlanItems>(modelBuilder);
            ConfigureAudit<Annex>(modelBuilder);
        }
        private static void ConfigureAudit<T>(ModelBuilder modelBuilder) where T : BaseEntity
        {
            modelBuilder.Entity<T>()
                .HasOne(x => x.CreateUser)
                .WithMany()
                .HasForeignKey(x => x.CreateUserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<T>()
                .HasOne(x => x.UpdateUser)
                .WithMany()
                .HasForeignKey(x => x.UpdateUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}