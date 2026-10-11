using Application.DTOs.Request;
using Application.DTOs.Response;
namespace Application.Interfaces.Services
{
    public interface IActivityService
    {
        Task<List<ActivityResponseDto>> GetByApplicationIdAsync(Guid applicationId);
        Task<ActivityResponseDto?> GetByIdAsync(Guid id);
        Task<ActivityResponseDto> AddAsync(Guid applicationId, AddActivityRequestDto model, Guid userId);
        Task<bool> UpdateAsync(Guid id, UpdateActivityRequestDto model, Guid userId);
        Task<bool> DeleteAsync(Guid id);
    }
}
