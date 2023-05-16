using GrooveHT.Shared.Models.Profile;

namespace GrooveHT.Server.Services.Profile
{
    public interface IProfileService
    {
        Task<bool> CreateProfileAsync(ProfileCreate model);
        Task<IEnumerable<ProfileListItem>> GetAllProfilesAsync();
        Task<ProfileDetail> GetProfileByIdAsync(int id);
        Task<bool> UpdateProfileAsync(ProfileEdit model);
        Task<bool> DeleteProfileAsync(int id);
    }
}
