using GrooveHT.Server.Data;
using GrooveHT.Server.Models;
using GrooveHT.Shared.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using static GrooveHT.Server.Services.Configuration.ConfigurationService;

namespace GrooveHT.Server.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationService(ApplicationDbContext context)
        {
            _context = context;
        }
        // If assigning ID to logged in person creating configuration
        //private string _userId;
        //public void SetUserId(string userId) => _userId = userId;
        public async Task<bool> CreateConfigurationAsync(ConfigurationCreate model)
        {
            var entity = new ConfigurationEntity
            {
                HabitId = model.HabitId,
                FrequencyId = model.FrequencyId,
                StartDate = DateTime.Now,
            };
            _context.Configurations.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }


        public async Task<IEnumerable<ConfigurationListItem>> GetAllConfigurationsAsync()
        {
            var configurationQuery =
                _context.Configurations
                .Select(entity =>
                new ConfigurationListItem
                {
                    Id = entity.Id,
                    HabitId = entity.HabitId,
                });
            return await configurationQuery.ToListAsync();
        }

        public async Task<ConfigurationDetail> GetConfigurationByIdAsync(int id)
        {
            var entity = await _context.Configurations.FindAsync(id);
            if (entity is null)
            {
                return null;
            }

            var configurationDetail = new ConfigurationDetail
            {
                Id = entity.Id,
                HabitId = entity.HabitId,
                FrequencyId = entity.FrequencyId,
                StartDate = entity.StartDate,
            };

            return configurationDetail;
        }

        public async Task<bool> UpdateConfigurationAsync(ConfigurationEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Configurations.FindAsync(model);
            entity.HabitId = model.HabitId;
            entity.FrequencyId = model.FrequencyId;
            entity.StartDate = model.StartDate;

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteConfigurationAsync(int id)
        {
            var entity = await _context.Configurations.FindAsync(id);
            _context.Configurations.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

