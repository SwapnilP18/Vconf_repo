using ConferenceApp.Models;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Data
{
    public class MultiTenantEntitiesContext : MultiTenantDbContext
    {
        public MultiTenantEntitiesContext(ITenantInfo tenantInfo) : base(tenantInfo)
        { }

        public MultiTenantEntitiesContext(ITenantInfo tenantInfo, DbContextOptions<MultiTenantEntitiesContext> options) :
       base(tenantInfo, options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasQueryFilter(p => !p.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
