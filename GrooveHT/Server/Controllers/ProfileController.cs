using GrooveHT.Server.Services.Profile;
using GrooveHT.Shared.Models.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrooveHT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<List<ProfileListItem>> GetAllProfilesAsync()
        {
            var profiles = await _profileService.GetAllProfilesAsync();
            return profiles.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var profile = await _profileService.GetProfileByIdAsync(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileCreate model)
        {
            if (model == null) return BadRequest();
            bool wasSuccessfull = await _profileService.CreateProfileAsync(model);
            if (wasSuccessfull) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProfileEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _profileService.UpdateProfileAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await _profileService.GetProfileByIdAsync(id);
            if (profile == null) return NotFound();
            bool wasSuccessful = await _profileService.DeleteProfileAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }
    }
}
