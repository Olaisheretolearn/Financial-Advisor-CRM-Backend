using FinCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.Infrastructure
{
    public class FinCRMContext : DbContext
    {
        public FinCRMContext(DbContextOptions<FinCRMContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "System Administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "Advisor",
                    Description = "Financial Advisor"
                }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
