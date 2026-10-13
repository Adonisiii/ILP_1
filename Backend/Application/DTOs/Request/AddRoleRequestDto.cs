using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Request
{
    public class AddRoleRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
