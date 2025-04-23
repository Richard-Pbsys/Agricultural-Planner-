using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using VHS.Data;
using VHS.Data.Infrastructure;
using VHS.Data.Repositories.Auth;
using VHS.Data.Repositories.Farming;
using VHS.Data.Repositories.Produce;
using VHS.Data.Repositories.Growth;
using VHS.Data.Repositories.Batches;
using VHS.Services.Auth;
using VHS.Services.Farming;
using VHS.Services.Produce;
using VHS.Services.Growth;
using VHS.Services.Batches;
using VHS.Services.Farming.Algorithm;

namespace VHS.Services
{
    public static class ServiceInitialization
    {
        private static readonly int COMMAND_TIMEOUT = (int)TimeSpan.FromMinutes(30).TotalSeconds;

        public static void ConfigureDatabaseProvider(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VHSConnection")
                ?? throw new InvalidOperationException("Database connection string is missing.");

            var assemblyName = typeof(VHSDBContext).Assembly.GetName().Name;

            services.AddDbContext<VHSDBContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(COMMAND_TIMEOUT);
                    sqlServerOptions.MigrationsAssembly(assemblyName);
                    sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                })
            );
        }

        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSettingRepository, UserSettingRepository>();
            services.AddScoped<IFarmRepository, FarmRepository>();
            services.AddScoped<IFarmTypeRepository, FarmTypeRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IRackRepository, RackRepository>();
            services.AddScoped<ILayerRepository, LayerRepository>();
            services.AddScoped<ITrayRepository, TrayRepository>();
            services.AddScoped<ITrayCurrentStateRepository, TrayCurrentStateRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeLightScheduleRepository, RecipeLightScheduleRepository>();
            services.AddScoped<IRecipeWaterScheduleRepository, RecipeWaterScheduleRepository>();
            services.AddScoped<ILightZoneRepository, LightZoneRepository>();
            services.AddScoped<ILightZoneScheduleRepository, LightZoneScheduleRepository>();
            services.AddScoped<IWaterZoneRepository, WaterZoneRepository>();
            services.AddScoped<IWaterZoneScheduleRepository, WaterZoneScheduleRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<IBatchConfigurationRepository, BatchConfigurationRepository>();

            // Register unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSettingService, UserSettingService>();
            services.AddScoped<IFarmService, FarmService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IRackService, RackService>();
            services.AddScoped<ILayerService, LayerService>();
            services.AddScoped<ITrayService, TrayService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeLightScheduleService, RecipeLightScheduleService>();
            services.AddScoped<IRecipeWaterScheduleService, RecipeWaterScheduleService>();
            services.AddScoped<ILightZoneService, LightZoneService>();
            services.AddScoped<ILightZoneScheduleService, LightZoneScheduleService>();
            services.AddScoped<IWaterZoneService, WaterZoneService>();
            services.AddScoped<IWaterZoneScheduleService, WaterZoneScheduleService>();
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<IBatchConfigurationService, BatchConfigurationService>();

            // Farm allocation planner
            services.AddScoped<BestFitTrayAllocator>();
            services.AddScoped<FarmTrayAllocator>();
            services.AddScoped<RackTypeTrayAllocator>();
            services.AddScoped<IFarmPlannerService, FarmPlannerService>();

            services.AddLogging();
        }
    }
}
