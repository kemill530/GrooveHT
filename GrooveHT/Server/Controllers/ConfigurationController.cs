using GrooveHT.Server.Services.Configuration;
using GrooveHT.Shared.Models.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configService;
        public ConfigurationController(IConfigurationService configService)
        {
            _configService = configService;
        }

        [HttpGet]
        public async Task<List<ConfigurationListItem>> Index()
        {
            var configurations = await _configService.GetAllConfigurationsAsync();
            return configurations.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Configuration(int id)
        {
            var configuration = await _configService.GetConfigurationByIdAsync(id);
            if (configuration == null) return NotFound();
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConfigurationCreate model)
        {
            if (model == null) return BadRequest();
            bool wasSuccessful = await _configService.CreateConfigurationAsync(model);
            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ConfigurationEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSucccessful = await _configService.UpdateConfigurationAsync(model);
            if (wasSucccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var configuration = await _configService.GetConfigurationByIdAsync(id);
            if (configuration == null) return NotFound();
            bool wasSuccessful = await _configService.DeleteConfigurationAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }
    }
}
