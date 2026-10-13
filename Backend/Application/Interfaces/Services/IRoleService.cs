using Application.DTOs.Request;
using Application.DTOs.Response;
namespace Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<List<RoleResponseDto>> GetAllAsync();
        Task<RoleResponseDto?> GetByIdAsync(Guid id);
        Task<RoleResponseDto> AddAsync(AddRoleRequestDto model);
    }
}