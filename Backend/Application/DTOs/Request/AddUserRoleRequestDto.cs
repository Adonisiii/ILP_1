using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Request
{
    public class AddUserRoleRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}