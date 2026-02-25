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

        public DbSet<User> Users { get; set; }
    }
}
