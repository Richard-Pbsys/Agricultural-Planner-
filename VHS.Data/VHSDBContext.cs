using System;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Mappings;
using VHS.Data.Models;
using VHS.Data.Models.Auth;
using VHS.Data.Models.Farming;
using VHS.Data.Models.Produce;
using VHS.Data.Models.Batches;
using VHS.Data.Models.Growth;

namespace VHS.Data
{
    public class VHSDBContext : DbContext
    {
        private static readonly int COMMAND_TIMEOUT = (int)TimeSpan.FromMinutes(60).TotalSeconds;

        public VHSDBContext(DbContextOptions<VHSDBContext> options) : base(options)
        {
            Database.SetCommandTimeout(COMMAND_TIMEOUT);
        }

        // Auth
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }

        // Farming
        public DbSet<Farm> Farms { get; set; }
        public DbSet<FarmType> FarmTypes { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Tray> Trays { get; set; }
        public DbSet<TrayCurrentState> TrayCurrentStates { get; set; }
        public DbSet<TrayTransaction> TrayTransactions { get; set; }

        // Produce
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeLightSchedule> RecipeLightSchedules { get; set; }
        public DbSet<RecipeWaterSchedule> RecipeWaterSchedules { get; set; }

        // Growth
        public DbSet<LightZone> LightZones { get; set; }
        public DbSet<LightZoneSchedule> LightZoneSchedules { get; set; }
        public DbSet<WaterZone> WaterZones { get; set; }
        public DbSet<WaterZoneSchedule> WaterZoneSchedules { get; set; }

        // Batches
        public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchConfiguration> BatchConfigurations { get; set; }
        public DbSet<BatchJournal> BatchJournals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Auth
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserSettingMap());

            // Farming
            modelBuilder.ApplyConfiguration(new FarmMap());
            modelBuilder.ApplyConfiguration(new FarmTypeMap());
            modelBuilder.ApplyConfiguration(new FloorMap());
            modelBuilder.ApplyConfiguration(new RackMap());
            modelBuilder.ApplyConfiguration(new LayerMap());
            modelBuilder.ApplyConfiguration(new TrayMap());
            modelBuilder.ApplyConfiguration(new TrayCurrentStateMap());
            modelBuilder.ApplyConfiguration(new TrayTransactionMap());

            // Produce
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new RecipeLightScheduleMap());
            modelBuilder.ApplyConfiguration(new RecipeWaterScheduleMap());

            // Growth
            modelBuilder.ApplyConfiguration(new LightZoneMap());
            modelBuilder.ApplyConfiguration(new LightZoneScheduleMap());
            modelBuilder.ApplyConfiguration(new WaterZoneMap());
            modelBuilder.ApplyConfiguration(new WaterZoneScheduleMap());

            // Batches
            modelBuilder.ApplyConfiguration(new BatchMap());
            modelBuilder.ApplyConfiguration(new BatchConfigurationMap());
            modelBuilder.ApplyConfiguration(new BatchJournalMap());


            modelBuilder.Entity<Farm>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<FarmType>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<Floor>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<Rack>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<Layer>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<Tray>().HasQueryFilter(x => x.DeletedDateTime == null);

            modelBuilder.Entity<Product>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<Recipe>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<RecipeLightSchedule>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<RecipeWaterSchedule>().HasQueryFilter(x => x.DeletedDateTime == null);

            modelBuilder.Entity<LightZone>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<LightZoneSchedule>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<WaterZone>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<WaterZoneSchedule>().HasQueryFilter(x => x.DeletedDateTime == null);

            modelBuilder.Entity<Batch>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<BatchConfiguration>().HasQueryFilter(x => x.DeletedDateTime == null);
            modelBuilder.Entity<BatchJournal>().HasQueryFilter(x => x.DeletedDateTime == null);
        }
    }
}
