using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _context;
        public ActivityRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Activity>> GetByApplicationIdAsync(Guid applicationId)
        {
            return await _context.Activities
                .Where(x => x.ApplicationRequestId == applicationId)
                .ToListAsync();
        }
        public async Task<Activity?> GetByIdAsync(Guid id)
        {
            return await _context.Activities
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Activity activity)
        {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Activity activity)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }
    }
}