using Application.DTOs.Request;
using Application.DTOs.Response;
namespace Application.Interfaces.Services
{
    public interface IUserRoleService
    {
        Task<List<UserRoleResponseDto>> GetByUserIdAsync(Guid userId);
        Task<UserRoleResponseDto> AddAsync(AddUserRoleRequestDto model);
        Task<bool> DeleteAsync(Guid userId, Guid roleId);
    }
}
