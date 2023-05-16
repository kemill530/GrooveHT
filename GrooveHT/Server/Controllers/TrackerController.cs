using GrooveHT.Server.Services.Tracker;
using GrooveHT.Shared.Models.Tracker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly ITrackerService _trackerService;

        public TrackerController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        [HttpGet]
        public async Task<List<TrackerListItem>> Index()
        {
            var trackers = await _trackerService.GetAllTrackersAsync();
            return trackers.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Tracker(int id)
        {
            var tracker = await _trackerService.GetTrackerByIdAsync(id);
            if (tracker == null) return NotFound();
            return Ok(tracker);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackerCreate model)
        {
            if (model == null) return BadRequest();
            bool wasSuccessful = await _trackerService.CreateTrackerAsync(model);
            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, TrackerEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _trackerService.UpdateTrackerAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tracker = await _trackerService.GetTrackerByIdAsync(id);
            if (tracker == null) return NotFound();
            bool wasSuccessful = await _trackerService.DeleteTrackerAsync(id);
            if (!wasSuccessful) return BadRequest(tracker);
            return Ok();
        }
    }
}
