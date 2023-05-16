using GrooveHT.Shared.Models.Tracker;

namespace GrooveHT.Server.Services.Tracker
{
    public interface ITrackerService
    {
        Task<bool> CreateTrackerAsync(TrackerCreate model);
        Task<IEnumerable<TrackerListItem>> GetAllTrackersAsync();
        Task<TrackerDetail> GetTrackerByIdAsync(int id);
        Task<bool> UpdateTrackerAsync(TrackerEdit model);
        Task<bool> DeleteTrackerAsync(int id);
    }
}
