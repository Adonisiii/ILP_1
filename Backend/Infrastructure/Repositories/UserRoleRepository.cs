using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;
        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserRole>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserRoles
                .AsNoTracking()
                .Include(x => x.Role)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task<UserRole?> GetByUserAndRoleAsync(Guid userId, Guid roleId)
        {
            return await _context.UserRoles
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        }
        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(UserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
