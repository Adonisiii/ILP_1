using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Infrastructure.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DateTime GetExpirationTime()
        {
            var minutes = _configuration.GetValue<int>("Jwt:ExpirationMinutes");
            if (minutes <= 0)
                throw new InvalidOperationException("JWT expiration nuk është konfiguruar.");
            return DateTime.UtcNow.AddMinutes(minutes);
        }
        public string GenerateToken(User user, IEnumerable<string> roles)
        {
            var key = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key mungon.");
            var issuer = _configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT Issuer mungon.");
            var audience = _configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT Audience mungon.");
            if (Encoding.UTF8.GetByteCount(key) < 32)
                throw new InvalidOperationException("JWT Key duhet të ketë së paku 32 bytes.");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(
                signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: GetExpirationTime(),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}