using FinCRM.Domain;
using FinCRM.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.Application.Services
{
    public class UserService
    {
        private readonly FinCRMContext _context;

        public UserService(FinCRMContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
