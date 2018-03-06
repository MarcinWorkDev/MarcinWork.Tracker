using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MarcinWorkTracker.Logic.Models;

namespace MarcinWorkTracker.Logic.Data
{
    public class MWTrackerDbContext : DbContext
    {
        private static Type[] auditEntities =
        {
            typeof(Shipment),
            typeof(Tracking),
            typeof(ProviderCompany)
        };

        public MWTrackerDbContext(DbContextOptions<MWTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Tracking> Tracking { get; set; }
        public DbSet<ProviderCompany> ProviderCompany { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (Type type in auditEntities)
            {
                builder.Entity(type).Property<DateTime?>("CreatedAt");
                //builder.Entity(type).Property<String>("CreatedBy");
                builder.Entity(type).Property<DateTime?>("ModifiedAt");
                //builder.Entity(type).Property<String>("ModifiedBy");
            }
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

                var modifiedAtProperty = entityType.FindProperty("ModifiedAt");
                //var modifiedByProperty = entityType.FindProperty("ModifiedBy");
                var createdAtProperty = entityType.FindProperty("CreatedAt");
                //var createdByProperty = entityType.FindProperty("CreatedBy");

                if (entry.State == EntityState.Modified && modifiedAtProperty != null)
                {
                    entry.Property("ModifiedAt").CurrentValue = DateTime.Now;
                    //entry.Property("ModifiedBy").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Added && createdAtProperty != null)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    //entry.Property("CreatedBy").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
