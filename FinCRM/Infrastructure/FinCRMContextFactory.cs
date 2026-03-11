using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinCRM.Infrastructure
{
    public class FinCRMContextFactory
        : IDesignTimeDbContextFactory<FinCRMContext>
    {
        public FinCRMContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinCRMContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=FINCRM_data;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new FinCRMContext(optionsBuilder.Options);
        }
    }
}