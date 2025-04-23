using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Blazored.LocalStorage;
using MudBlazor.Services;
using VHS.Services.Auth;

namespace VHS.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Configuration.AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", optional: true, reloadOnChange: true);

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddLocalization();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddMudServices();

        var baseAddress = builder.HostEnvironment.BaseAddress;
        var apiUrl = builder.Configuration["ApiURL"] ?? baseAddress;

        builder.Services.AddHttpClient("AuthenticatedClient.ServerAPI", client =>
        {
            client.BaseAddress = new Uri(apiUrl);
            client.Timeout = TimeSpan.FromMinutes(30); // Set the timeout to 30 minutes
        })
        .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient("AuthenticatedClient.ServerAPI"));

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("Auth0", options.ProviderOptions);
            options.ProviderOptions.ResponseType = "code";
            options.ProviderOptions.PostLogoutRedirectUri = baseAddress;
            options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]!);
        }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

        // Initialize all client service registrations
        ClientServiceInitialization.Initialize(builder.Services);

        var host = builder.Build();

        await host.RunAsync();
    }
}
