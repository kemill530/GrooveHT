using GrooveHT.Shared.Models.Habit;

namespace GrooveHT.Server.Services.Habit
{
    public interface IHabitService
    {
        Task<bool> CreateHabitAsync(HabitCreate model);
        Task<IEnumerable<HabitListItem>> GetAllHabitsAsync();
        Task<HabitDetail> GetHabitByIdAsync(int id);
        Task<bool> UpdateHabitAsync(HabitEdit model);
        Task<bool> DeleteHabitAsync(int id);
    }
}
