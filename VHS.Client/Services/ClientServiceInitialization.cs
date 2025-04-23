using VHS.Client.Services;
using VHS.Client.Services.Auth;
using VHS.Client.Services.Farming;
using VHS.Client.Services.Produce;
using VHS.Client.Services.Growth;
using VHS.Client.Services.Batches;
using VHS.Client.Common;

namespace VHS.Client
{
    public static class ClientServiceInitialization
    {
        public static void Initialize(IServiceCollection services)
        {
            // General
            services.AddScoped<LocalStorage>();
            services.AddScoped<PageTitleService>();

            // Auth
            services.AddScoped<UserClientService>();
            services.AddScoped<UserSettingClientService>();

            // Farming
            services.AddScoped<FarmClientService>();
            services.AddScoped<FloorClientService>();
            services.AddScoped<RackClientService>();
            services.AddScoped<LayerClientService>();
            services.AddScoped<TrayClientService>();

            // Produce
            services.AddScoped<ProductClientService>();
            services.AddScoped<RecipeClientService>();
            services.AddScoped<RecipeLightScheduleClientService>();
            services.AddScoped<RecipeWaterScheduleClientService>();

            // Growth
            services.AddScoped<LightZoneClientService>();
            services.AddScoped<LightZoneScheduleClientService>();
            services.AddScoped<WaterZoneClientService>();
            services.AddScoped<WaterZoneScheduleClientService>();

            // Batches
            services.AddScoped<BatchClientService>();
            services.AddScoped<BatchConfigurationClientService>();
        }
    }
}
