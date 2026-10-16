using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            ITokenService tokenService,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto model)
        {
            var email = model.Email.Trim();
            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null)
                throw new InvalidOperationException("Ky email ekziston.");
            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 8)
                throw new ArgumentException("Fjalëkalimi duhet të ketë së paku 8 karaktere.");
            var role = await _roleRepository.GetByNameAsync("Tatimpagues");
            if (role == null)
                throw new InvalidOperationException("Roli Tatimpagues nuk është konfiguruar.");
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Surname = model.Surname,
                Email = email,
                Address = model.Address,
                PersonalNumber = model.PersonalNumber,
                PhoneNumber = model.PhoneNumber
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
            await _userRepository.AddAsync(user);
            await _userRoleRepository.AddAsync(new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                RoleId = role.Id
            });
            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = _tokenService.GenerateToken(user, new[] { role.Name }),
                ExpiresAt = _tokenService.GetExpirationTime()
            };
        }
        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email.Trim());
            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
                return null;
            var result = _passwordHasher.VerifyHashedPassword(
                user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed)
                return null;
            var userRoles = await _userRoleRepository.GetByUserIdAsync(user.Id);
            var roles = userRoles.Select(x => x.Role.Name).ToList();
            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = _tokenService.GenerateToken(user, roles),
                ExpiresAt = _tokenService.GetExpirationTime()
            };
        }
    }
}