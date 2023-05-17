using GrooveHT.Server.Data;
using GrooveHT.Server.Models;
using GrooveHT.Shared.Models.Habit;
using Microsoft.EntityFrameworkCore;

namespace GrooveHT.Server.Services.Habit
{
    public class HabitService : IHabitService
    {
        private readonly ApplicationDbContext _context;
        public HabitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateHabitAsync(HabitCreate model)
        {
            var entity = new HabitEntity
            {
                HabitTitle = model.HabitTitle,
                Description = model.Description,
            };
            _context.Habits.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<HabitListItem>> GetAllHabitsAsync()
        {
            var habitQuery =
                _context.Habits
                .Select(entity =>
                    new HabitListItem
                    {
                        Id = entity.Id,
                        HabitTitle = entity.HabitTitle
                    });
            return await habitQuery.ToListAsync();
        }

        public async Task<HabitDetail> GetHabitByIdAsync(int id)
        {
            var entity = await _context.Habits.FindAsync(id);
            if (entity is null)
            {
                return null;
            }

            var habitDetail = new HabitDetail
            {
                Id = entity.Id,
                HabitTitle = entity.HabitTitle,
                Description = entity.Description,
            };

            return habitDetail;
        }

        public async Task<bool> UpdateHabitAsync(HabitEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Habits.FindAsync(model);
            entity.HabitTitle = model.HabitTitle;
            entity.Description = model.Description;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteHabitAsync(int id)
        {
            var entity = await _context.Habits.FindAsync(id);
            _context.Habits.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
