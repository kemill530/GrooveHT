using Duende.IdentityServer.EntityFramework.Options;
using GrooveHT.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GrooveHT.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<ConfigurationEntity> Configurations { get; set; }
        public DbSet<FrequencyEntity> Frequencies { get; set; }
        public DbSet<HabitEntity> Habits { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<TrackerEntity> Trackers { get; set; }
    }
}