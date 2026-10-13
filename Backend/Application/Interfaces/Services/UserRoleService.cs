using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
namespace Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserRoleService(
            IUserRoleRepository repository,
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<List<UserRoleResponseDto>> GetByUserIdAsync(Guid userId)
        {
            var userRoles = await _repository.GetByUserIdAsync(userId);
            return userRoles.Select(x => new UserRoleResponseDto
            {
                Id = x.Id,
                UserId = x.UserId,
                RoleId = x.RoleId,
                RoleName = x.Role.Name
            }).ToList();
        }
        public async Task<UserRoleResponseDto> AddAsync(AddUserRoleRequestDto model)
        {
            var user = await _userRepository.GetByIdAsync(model.UserId);
            if (user == null)
                throw new KeyNotFoundException("Përdoruesi nuk ekziston.");
            var role = await _roleRepository.GetByIdAsync(model.RoleId);
            if (role == null)
                throw new KeyNotFoundException("Roli nuk ekziston.");
            var existing = await _repository.GetByUserAndRoleAsync(model.UserId, model.RoleId);
            if (existing != null)
                throw new InvalidOperationException("Përdoruesi e ka këtë rol.");
            var userRole = new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                RoleId = model.RoleId
            };
            await _repository.AddAsync(userRole);
            return new UserRoleResponseDto
            {
                Id = userRole.Id,
                UserId = userRole.UserId,
                RoleId = userRole.RoleId,
                RoleName = role.Name
            };
        }
        public async Task<bool> DeleteAsync(Guid userId, Guid roleId)
        {
            var userRole = await _repository.GetByUserAndRoleAsync(userId, roleId);
            if (userRole == null)
                return false;
            await _repository.DeleteAsync(userRole);
            return true;
        }
    }
}