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



        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Advisor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            client.CreatedAt = DateTimeOffset.UtcNow;
            client.UpdatedAt = DateTimeOffset.UtcNow;

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }



    }
}

