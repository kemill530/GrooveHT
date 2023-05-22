using GrooveHT.Server.Data;
using GrooveHT.Server.Models;
using GrooveHT.Shared.Models.Frequency;
using Microsoft.EntityFrameworkCore;

namespace GrooveHT.Server.Services.Frequency
{
    public class FrequencyService : IFrequencyService
    {
        private readonly ApplicationDbContext _context;
        public FrequencyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateFrequencyAsync(FrequencyCreate model)
        {
            var entity = new FrequencyEntity
            {
                Frequency = model.Frequency,
            };
            _context.Frequencies.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<FrequencyListItem>> GetAllFrequenciesAsync()
        {
            var frequencyQuery =
                _context.Frequencies
                .Select(entity =>
                    new FrequencyListItem
                    {
                        Id = entity.Id,
                        Frequency = entity.Frequency
                    });
            return await frequencyQuery.ToListAsync();
        }

        public async Task<FrequencyDetail> GetFrequencyByIdAsync(int id)
        {
            var entity = await _context.Frequencies.FindAsync(id);
            if (entity is null)
            {
                return null;
            }

            var frequencyDetail = new FrequencyDetail
            {
                Id = entity.Id,
                Frequency = entity.Frequency,
            };

            return frequencyDetail;
        }
    }
}
