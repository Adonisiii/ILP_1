using Application.DTOs.Request;
using Application.DTOs.Response;
namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto?> GetByIdAsync(Guid id);
        Task<UserResponseDto> AddAsync(AddUserRequestDto model);
        Task<bool> UpdateAsync(Guid id, UpdateUserRequestDto model);
    }
}