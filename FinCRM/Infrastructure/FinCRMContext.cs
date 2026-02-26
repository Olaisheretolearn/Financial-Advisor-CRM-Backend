using FinCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.Infrastructure
{
    public class FinCRMContext : DbContext
    {
        public FinCRMContext(DbContextOptions<FinCRMContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
