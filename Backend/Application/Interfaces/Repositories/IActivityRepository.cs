using Domain.Entities;
namespace Application.Interfaces.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetByApplicationIdAsync(Guid applicationId);
        Task<Activity?> GetByIdAsync(Guid id);
        Task AddAsync(Activity activity);
        Task UpdateAsync(Activity activity);
        Task DeleteAsync(Activity activity);
    }
}