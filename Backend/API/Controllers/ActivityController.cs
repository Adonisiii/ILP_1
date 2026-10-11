using System.Security.Claims;
using Application.DTOs.Request;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _service;
        public ActivityController(IActivityService service)
        {
            _service = service;
        }
        [HttpGet("application/{applicationId:guid}")]
        public async Task<IActionResult> GetByApplicationId(Guid applicationId)
        {
            var activities = await _service.GetByApplicationIdAsync(applicationId);
            return Ok(activities);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var activity = await _service.GetByIdAsync(id);
            if (activity == null)
                return NotFound();
            return Ok(activity);
        }
        [HttpPost("{applicationId:guid}")]
        public async Task<IActionResult> Add(Guid applicationId, AddActivityRequestDto model)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized();
            if (string.IsNullOrWhiteSpace(model.Code) || string.IsNullOrWhiteSpace(model.Description))
                return BadRequest("Code dhe Description janë të detyrueshme.");
            var activity = await _service.AddAsync(applicationId, model, userId);
            return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateActivityRequestDto model)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized();
            if (string.IsNullOrWhiteSpace(model.Code) || string.IsNullOrWhiteSpace(model.Description))
                return BadRequest("Code dhe Description janë të detyrueshme.");
            var updated = await _service.UpdateAsync(id, model, userId);
            if (!updated)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
        private bool TryGetUserId(out Guid userId)
        {
            var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(value, out userId);
        }
    }
}