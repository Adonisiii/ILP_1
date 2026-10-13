namespace Application.DTOs.Response
{
    public class UserRoleResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}