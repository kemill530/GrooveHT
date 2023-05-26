using GrooveHT.Server.Services.Habit;
using GrooveHT.Shared.Models.Habit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService _habitService;
        public HabitController(IHabitService habitService)
        {
            _habitService = habitService;
        }

        public async Task<List<HabitListItem>> Index()
        {
            var habits = await _habitService.GetAllHabitsAsync();
            return habits.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Habit(int id)
        {
            var habit = await _habitService.GetHabitByIdAsync(id);
            if (habit == null) return NotFound();
            return Ok(habit);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HabitCreate model)
        {
            if (model == null) return BadRequest();
            bool wasSuccessfull = await _habitService.CreateHabitAsync(model);
            if (wasSuccessfull) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, HabitEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _habitService.UpdateHabitAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var habit = await _habitService.GetHabitByIdAsync(id);
            if (habit == null) return NotFound();
            bool wasSuccessful = await _habitService.DeleteHabitAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }
    }
}
