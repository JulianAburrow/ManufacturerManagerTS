using ManufacturerManagerTS.DataAccess.ConfigurationClasses;
using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.DataAccess
{
    public class ManufacturerManagerTSContext : DbContext
    {
        #region Properties

        public int UserId { get; set; }

        #endregion

        #region Constructor

        public ManufacturerManagerTSContext(DbContextOptions<ManufacturerManagerTSContext> options)
            : base(options)
        {
        }

        #endregion

        #region DbSets

        public DbSet<ColourEntity> Colour { get; set; }

        public DbSet<ColourJustificationEntity> ColourJustification { get; set; }

        public DbSet<ManufacturerEntity> Manufacturer { get; set; }

        public DbSet<ManufacturerStatusEntity> ManufacturerStatus { get; set; }

        public DbSet<StaffMemberEntity> StaffMember { get; set; }

        public DbSet<WidgetEntity> Widget { get; set; }

        public DbSet<WidgetStatusEntity> WidgetStatus { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColourJustificationConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new StaffMemberConfiguration());
            modelBuilder.ApplyConfiguration(new WidgetConfiguration());
            modelBuilder.ApplyConfiguration(new ColourConfiguration());
            modelBuilder.ApplyConfiguration(new WidgetStatusConfiguration());
        }

        #endregion

        #region SaveChangesAsync

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        if (changedEntity.Entity is IAuditableObject objAdded)
                        {
                            objAdded.Created = DateTime.Now;
                            objAdded.CreatedById = UserId;
                            objAdded.LastUpdated = DateTime.Now;
                            objAdded.LastUpdatedById = UserId;
                        }
                        break;
                    case EntityState.Modified:
                        if (changedEntity.Entity is IAuditableObject objModified)
                        {
                            objModified.LastUpdated = DateTime.Now;
                            objModified.LastUpdatedById = UserId;
                        }
                        break;
                }
            }

            return await base.SaveChangesAsync();
        }

        #endregion
    }
}
