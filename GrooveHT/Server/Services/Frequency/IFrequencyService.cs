using GrooveHT.Shared.Models.Frequency;
using GrooveHT.Shared.Models.Habit;

namespace GrooveHT.Server.Services.Frequency
{
    public interface IFrequencyService
    {
        Task<bool> CreateFrequencyAsync(FrequencyCreate model);
        Task<IEnumerable<FrequencyListItem>> GetAllFrequenciesAsync();
        Task<FrequencyDetail> GetFrequencyByIdAsync(int id);

    }
}
