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

        public async Task<User> CreateUserAsync(User user)
        {
            user.CreatedAt = DateTimeOffset.UtcNow;
            user.UpdatedAt = DateTimeOffset.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User?> UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.RoleId = updatedUser.RoleId;
            existingUser.IsActive = updatedUser.IsActive;
            existingUser.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        // soft deklete is probably what's best
        public async Task<bool> DeactivateUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return false;
            }

            user.IsActive = false;
            user.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
