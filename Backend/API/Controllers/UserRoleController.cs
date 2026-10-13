using Application.DTOs.Request;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _service;
        public UserRoleController(IUserRoleService service)
        {
            _service = service;
        }
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var roles = await _service.GetByUserIdAsync(userId);
            return Ok(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddUserRoleRequestDto model)
        {
            try
            {
                var result = await _service.AddAsync(model);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpDelete("user/{userId:guid}/role/{roleId:guid}")]
        public async Task<IActionResult> Delete(Guid userId, Guid roleId)
        {
            var deleted = await _service.DeleteAsync(userId, roleId);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}