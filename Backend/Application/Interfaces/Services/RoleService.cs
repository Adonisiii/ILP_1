using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<RoleResponseDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(x => new RoleResponseDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        public async Task<RoleResponseDto?> GetByIdAsync(Guid id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null)
                return null;
            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
        public async Task<RoleResponseDto> AddAsync(AddRoleRequestDto model)
        {
            var name = model.Name.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Emri i rolit është i detyrueshëm.");
            var existing = await _repository.GetByNameAsync(name);
            if (existing != null)
                throw new InvalidOperationException("Ky rol ekziston.");
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            await _repository.AddAsync(role);
            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}