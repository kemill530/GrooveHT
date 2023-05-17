using GrooveHT.Server.Data;
using GrooveHT.Server.Models;
using GrooveHT.Shared.Models.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrooveHT.Server.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProfileAsync(ProfileCreate model)
        {
            var entity = new ProfileEntity
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var passwordHasher = new PasswordHasher<ProfileEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _context.Profiles.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ProfileListItem>> GetAllProfilesAsync()
        {
            var profileQuery =
                _context.Profiles
                .Select(entity =>
                    new ProfileListItem
                    {
                        Id = entity.Id,
                        UserName = entity.UserName,
                    });
            return await profileQuery.ToListAsync();
        }

        public async Task<ProfileDetail> GetProfileByIdAsync(int id)
        {
            var entity = await _context.Profiles.FindAsync(id);
            if (entity is null)
            {
                return null;
            }

            var profileDetail = new ProfileDetail
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                InProgress = entity.InProgress
            };

            return profileDetail;

        }

        public async Task<bool> UpdateProfileAsync(ProfileEdit model)
        {
            if (model == null) return false;
            var entity = await _context.Profiles.FindAsync(model);
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;

            var passwordHasher = new PasswordHasher<ProfileEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteProfileAsync(int id)
        {
            var entity = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
