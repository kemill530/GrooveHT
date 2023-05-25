using GrooveHT.Server.Services.Configuration;
using GrooveHT.Server.Services.Tracker;
using GrooveHT.Shared.Models.Configuration;
using GrooveHT.Shared.Models.Tracker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly ITrackerService _trackerService;
        public ConfigurationController(IConfigurationService configService, ITrackerService trackerService)
        {
            _configurationService = configService;
            _trackerService = trackerService;
        }

        [HttpGet]
        public async Task<List<ConfigurationListItem>> Index()
        {
            var configurations = await _configurationService.GetAllConfigurationsAsync();
            return configurations.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Configuration(int id)
        {
            var configuration = await _configurationService.GetConfigurationByIdAsync(id);
            if (configuration == null) return NotFound();
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConfigurationCreate model)
        {
            if (model == null) return BadRequest();
            var response = await _configurationService.CreateConfigurationAsync(model);
            if (response.IsSuccessful)
            {
                bool trackerCreated = await _trackerService.CreateTrackerAsync(new TrackerCreate() {ConfigurationId = response.CreatedConfigId});
                if(trackerCreated)
                {
                    return Ok();
                }
                return Ok();
            }
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ConfigurationEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSucccessful = await _configurationService.UpdateConfigurationAsync(model);
            if (wasSucccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var configuration = await _configurationService.GetConfigurationByIdAsync(id);
            if (configuration == null) return NotFound();
            bool wasSuccessful = await _configurationService.DeleteConfigurationAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }
    }
}
