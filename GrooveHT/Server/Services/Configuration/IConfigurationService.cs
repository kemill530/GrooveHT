using GrooveHT.Shared.Models.Configuration;

namespace GrooveHT.Server.Services.Configuration
{
    public interface IConfigurationService
    {
        Task<ConfigurationCreatedResp> CreateConfigurationAsync(ConfigurationCreate model);
        Task<IEnumerable<ConfigurationListItem>> GetAllConfigurationsAsync();
        Task<ConfigurationDetail> GetConfigurationByIdAsync(int id);
        Task<bool> UpdateConfigurationAsync(ConfigurationEdit model);
        Task<bool> DeleteConfigurationAsync(int id);
    }
}
