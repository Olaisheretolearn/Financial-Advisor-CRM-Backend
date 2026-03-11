using FinCRM.Infrastructure;
using FinCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.Application.Services
{
    public class ClientService
    {
        private readonly FinCRMContext _context;

        public ClientService(FinCRMContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients
                .Include(c => c.Advisor)
                .ToListAsync();
        }






    }
}

