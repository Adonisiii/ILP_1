using Domain.Entities;
namespace Application.Interfaces.Repositories
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetByUserIdAsync(Guid userId);
        Task<UserRole?> GetByUserAndRoleAsync(Guid userId, Guid roleId);
        Task AddAsync(UserRole userRole);
        Task DeleteAsync(UserRole userRole);
    }
}