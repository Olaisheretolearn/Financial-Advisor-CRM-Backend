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
        public async Task<Client?> UpdateClientAsync(int id, Client updatedClient)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
                return null;

            client.FirstName = updatedClient.FirstName;
            client.LastName = updatedClient.LastName;
            client.Email = updatedClient.Email;
            client.PhoneNumber = updatedClient.PhoneNumber;
            client.RiskTolerance = updatedClient.RiskTolerance;
            client.KycCompleted = updatedClient.KycCompleted;
            client.IsActive = updatedClient.IsActive;
            client.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
                return false;
            client.IsActive = false;
            client.UpdatedAt = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();

            return true;
        }




    }
}

