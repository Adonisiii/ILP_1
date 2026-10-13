using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(MapToDto).ToList();
        }
        public async Task<UserResponseDto?> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : MapToDto(user);
        }
        public async Task<UserResponseDto> AddAsync(AddUserRequestDto model)
        {
            var existing = await _repository.GetByEmailAsync(model.Email);
            if (existing != null)
                throw new InvalidOperationException("Ky email ekziston.");
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Address = model.Address,
                PersonalNumber = model.PersonalNumber,
                PhoneNumber = model.PhoneNumber
            };
            await _repository.AddAsync(user);
            return MapToDto(user);
        }
        public async Task<bool> UpdateAsync(Guid id, UpdateUserRequestDto model)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                return false;
            var existing = await _repository.GetByEmailAsync(model.Email);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Ky email ekziston.");
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PersonalNumber = model.PersonalNumber;
            user.PhoneNumber = model.PhoneNumber;
            await _repository.UpdateAsync(user);
            return true;
        }
        private static UserResponseDto MapToDto(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Address = user.Address,
                PersonalNumber = user.PersonalNumber,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}