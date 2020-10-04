using WebApplication1.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ConferenceApp.Models;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Finbuckle.MultiTenant;
using System.Threading;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IMultiTenantDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                UserName = "SuperAdmin",
                Email="superadmin@gmail.com",
                PasswordHash = hasher.HashPassword(null, "007Katrina#"),
            });
            base.OnModelCreating(builder);

            builder.ConfigureMultiTenant();
            builder.Entity<Meeting>().IsMultiTenant();
            builder.Entity<Room>().IsMultiTenant();
            builder.Entity<RoomConfiguration>().IsMultiTenant();
            builder.Entity<RoomSetting>().IsMultiTenant();
            builder.Entity<User>().IsMultiTenant();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.EnforceMultiTenant();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            this.EnforceMultiTenant();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomConfiguration> RoomConfigurations { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<RoomSetting> RoomSettings { get; set; }
        public DbSet<UserRoomMapping> UserRoomMappings { get; set; }

        public ITenantInfo TenantInfo => throw new NotImplementedException();

        public TenantMismatchMode TenantMismatchMode => throw new NotImplementedException();

        public TenantNotSetMode TenantNotSetMode => throw new NotImplementedException();
    }
}