using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
namespace Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;
        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ActivityResponseDto>> GetByApplicationIdAsync(Guid applicationId)
        {
            var activities = await _repository.GetByApplicationIdAsync(applicationId);
            return activities.Select(x => new ActivityResponseDto
            {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                ApplicationRequestId = x.ApplicationRequestId
            }).ToList();
        }
        public async Task<ActivityResponseDto?> GetByIdAsync(Guid id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                return null;
            return new ActivityResponseDto
            {
                Id = activity.Id,
                Code = activity.Code,
                Description = activity.Description,
                ApplicationRequestId = activity.ApplicationRequestId
            };
        }
        public async Task<ActivityResponseDto> AddAsync(Guid applicationId, AddActivityRequestDto model, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(model.Code) || string.IsNullOrWhiteSpace(model.Description))
                throw new ArgumentException("Code dhe Description janë të detyrueshme.");
            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Description = model.Description,
                ApplicationRequestId = applicationId,
                CreateUserId = userId,
                CreateDate = DateTime.UtcNow
            };
            await _repository.AddAsync(activity);
            return new ActivityResponseDto
            {
                Id = activity.Id,
                Code = activity.Code,
                Description = activity.Description,
                ApplicationRequestId = activity.ApplicationRequestId
            };
        }
        public async Task<bool> UpdateAsync(Guid id, UpdateActivityRequestDto model, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(model.Code) || string.IsNullOrWhiteSpace(model.Description))
                throw new ArgumentException("Code dhe Description janë të detyrueshme.");
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                return false;
            activity.Code = model.Code;
            activity.Description = model.Description;
            activity.UpdateUserId = userId;
            activity.UpdateDate = DateTime.UtcNow;
            await _repository.UpdateAsync(activity);
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                return false;
            await _repository.DeleteAsync(activity);
            return true;
        }
    }
}