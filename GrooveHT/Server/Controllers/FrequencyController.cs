using GrooveHT.Server.Services.Frequency;
using GrooveHT.Server.Services.Habit;
using GrooveHT.Shared.Models.Configuration;
using GrooveHT.Shared.Models.Frequency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        private readonly IFrequencyService _frequencyService;
        public FrequencyController(IFrequencyService frequencyService)
        {
            _frequencyService = frequencyService;
        }
        [HttpGet]
        public async Task<List<FrequencyListItem>> Index()
        {
            var frequencies = await _frequencyService.GetAllFrequenciesAsync();
            return frequencies.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Frequency(int id)
        {
            var frequency = await _frequencyService.GetFrequencyByIdAsync(id);
            if (frequency == null) return NotFound();
            return Ok(frequency);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FrequencyCreate model)
        {
            if (model == null) return BadRequest();
            bool wasSuccessful = await _frequencyService.CreateFrequencyAsync(model);
            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

    }
}
