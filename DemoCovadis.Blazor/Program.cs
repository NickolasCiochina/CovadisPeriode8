using DemoCovadis.Blazor;
using DemoCovadis.Shared.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5077") });
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<UserHttpClient>();
        builder.Services.AddScoped<ReserveringHttpClient>();

        await builder.Build().RunAsync();
    }
}
