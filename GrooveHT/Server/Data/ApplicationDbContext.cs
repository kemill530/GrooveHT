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
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
    }
}