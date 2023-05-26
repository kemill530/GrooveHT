using AutoMapper;
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
        public async Task<ConfigurationCreatedResp> CreateConfigurationAsync(ConfigurationCreate model)
        {
            var response = new ConfigurationCreatedResp();
            var entity = new ConfigurationEntity
            {
                Name = model.Name,
                HabitId = model.HabitId,
                FrequencyId = model.FrequencyId,
                StartDate = DateTimeOffset.Now,
            };
            _context.Configurations.Add(entity);
            response.IsSuccessful = await _context.SaveChangesAsync() == 1;
            response.CreatedConfigId = entity.Id;
            return response;
        }


        public async Task<IEnumerable<ConfigurationListItem>> GetAllConfigurationsAsync()
        {
            var configurationQuery =
                _context.Configurations
                .Select(entity =>
                new ConfigurationListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    HabitId = entity.HabitId,
                });
            return await configurationQuery.ToListAsync();
        }

        public async Task<ConfigurationDetail> GetConfigurationByIdAsync(int id)
        {
            var entity = await _context.Configurations
                .Include(x => x.Habit)
                .Include(x => x.Frequency)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
            {
                return null;
            }

            var configurationDetail = new ConfigurationDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                HabitId = entity.HabitId,
                HabitName = entity.Habit.HabitTitle,
                FrequencyId = entity.FrequencyId,
                FrequencyType = entity.Frequency.FrequencyType,
                StartDate = entity.StartDate,
            };

            return configurationDetail;
        }

        public async Task<bool> UpdateConfigurationAsync(ConfigurationEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Configurations.FindAsync(model.Id);
            entity.Name = model.Name;
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

