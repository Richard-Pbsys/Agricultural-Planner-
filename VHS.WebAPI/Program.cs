using Auth0Net.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
//using VHS.Client.Hubs;
using VHS.Data;
using VHS.Services;
using VHS.WebAPI.Middlewares;

namespace VHS.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
            
            // Configure Sentry
            builder.WebHost.UseSentry(o =>
            {
                o.Dsn = builder.Configuration["Sentry:Dsn"];
                o.Debug = builder.Configuration.GetValue<bool>("Sentry:Debug");
                o.TracesSampleRate = builder.Configuration.GetValue<double>("Sentry:TracesSampleRate");
            });

            

            // Read CORS allowed origins
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.SetIsOriginAllowed(origin =>
                    {
                        // Allow all localhost origins (including different ports)
                        if (origin.Contains("localhost", StringComparison.OrdinalIgnoreCase))
                            return true;

                        // Allow explicitly defined origins from configuration
                        return allowedOrigins?.Contains(origin) ?? false;
                    })
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // Add Controllers & API Endpoints
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Enable Swagger
            builder.Services.AddSwaggerGen();

            // Configure Authentication with JWT Bearer
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth0:Authority"];
                options.Audience = builder.Configuration["Auth0:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            // Add Auth0 Clients
            builder.Services.AddAuth0AuthenticationClient(config =>
            {
                config.Domain = builder.Configuration["Auth0:Authority"]!;
                config.ClientId = builder.Configuration["Auth0:M2MClientId"];
                config.ClientSecret = builder.Configuration["Auth0:M2MClientSecret"];
            });
            builder.Services.AddAuth0ManagementClient().AddManagementAccessToken();

            //builder.Services.AddSignalR();

            // Configure database connection
            ServiceInitialization.ConfigureDatabaseProvider(builder.Services, builder.Configuration);

            // Initialize all dependencies for services
            ServiceInitialization.Initialize(builder.Services, builder.Configuration);
                        
            var app = builder.Build();

            // Automatically updates database schema by auto-applying migrations
            using (var scope = app.Services.CreateScope())
            {
                void MigrateDatabase<T>() where T : DbContext
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<T>();
                    dbContext.Database.Migrate();
                }
                MigrateDatabase<VHSDBContext>();
            }

            // Enable CORS
            app.UseCors("AllowBlazorClient");

            // Middlewares
            // Enable request tracing middleware
            app.UseSentryTracing();

            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
            {
                // Enable Swagger middleware
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VHS.WebAPI v1");
                    c.RoutePrefix = "swagger";
                    // Visit http://localhost:5001/swagger/index.html (port 5001 for http, 7001 for https set on launch settings)
                });
            }

            // Remove X-Powered-By header
            app.UseMiddleware<RemoveXPoweredByMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers().RequireAuthorization();

            //app.MapHub<VHSHub>("/VHSHub");

            app.Run();
        }

        public static async Task ApplyDBChangeAsync(IServiceProvider scopedServices)
        {
            var context = scopedServices.GetRequiredService<VHSDBContext>();
            await context.Database.MigrateAsync();
        }

    }
}
