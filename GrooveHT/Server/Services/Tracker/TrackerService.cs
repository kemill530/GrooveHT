using GrooveHT.Server.Data;
using GrooveHT.Server.Models;
using GrooveHT.Shared.Models.Tracker;
using Microsoft.EntityFrameworkCore;

namespace GrooveHT.Server.Services.Tracker
{
    public class TrackerService : ITrackerService
    {
        private readonly ApplicationDbContext _context;
        public TrackerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTrackerAsync(TrackerCreate request)
        {
            var entity = new TrackerEntity
            {
                ConfigurationId = request.ConfigurationId,
                TaskCompleted = true,
                Date = DateTime.UtcNow,
                Notes = ""
            };
            _context.Trackers.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<TrackerListItem>> GetAllTrackersAsync()
        {
            var trackerQuery =
                _context.Trackers
                .Include(x => x.Configuration)
                .Select(entity =>
                    new TrackerListItem
                    {
                        Id = entity.Id,
                        ConfigurationName = entity.Configuration.Name,
                        Date = entity.Date
                    });
            return await trackerQuery.ToListAsync();
        }
        public async Task<IEnumerable<TrackerListItem>> GetTrackersByConfigurationIdAsync(TrackerHistoryList request)
        {
            var trackerQuery =
                _context.Trackers
                .Include(x => x.Configuration)
                .Where(entity => entity.ConfigurationId == request.ConfigurationId )
                .Select(entity =>
                    new TrackerListItem
                    {
                        Id = entity.Id,
                        ConfigurationName = entity.Configuration.Name,
                        TaskCompleted = entity.TaskCompleted,
                        Date = entity.Date

                    });
            return await trackerQuery.ToListAsync();
        }

        public async Task<TrackerDetail> GetTrackerByIdAsync(int id)
        {
            var entity = await _context.Trackers
                .Include(x => x.Configuration)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }

            var trackerDetail = new TrackerDetail
            {
                Id = entity.Id,
                ConfigurationId = entity.ConfigurationId,
                ConfigurationName = entity.Configuration.Name,
                TaskCompleted = entity.TaskCompleted,
                Date = entity.Date,
                Notes = entity.Notes,
            };

            return trackerDetail;
        }



        public async Task<bool> UpdateTrackerAsync(TrackerEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Trackers.FindAsync(model);
            entity.TaskCompleted = model.TaskCompleted;
            entity.Notes = model.Notes;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteTrackerAsync(int id)
        {
            var entity = await _context.Trackers.FindAsync(id);
            _context.Trackers.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
