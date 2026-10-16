using Application.DTOs.Request;
using Application.DTOs.Response;
namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto model);
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto model);
    }
}
