using FinCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.Data
{
    public class FinCRMContext : DbContext
    {
        public FinCRMContext(DbContextOptions<FinCRMContext> options)
            : base(options)
        {
        }

        // map our model to database
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


            modelBuilder.Entity<User>().HasData(
    new User
    {
        Id = 1,
        FirstName = "Richard",
        LastName = "Smith",
        Email = "catchmeifyoucan@gmail.com",
        PasswordHash = "123",
        RoleId = 1,
        IsActive = true,
        CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero),
        UpdatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
    },
    new User
    {
        Id = 2,
        FirstName = "Victory",
        LastName = "Smither",
        Email = "catchmeifyoucant@gmail.com",
        PasswordHash = "1234",
        RoleId = 2,
        IsActive = true,
        CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero),
        UpdatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
    }
);

        }
        public DbSet<User> Users { get; set; }
    }
}
