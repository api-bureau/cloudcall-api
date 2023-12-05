using ApiBureau.CloudCall.Api.Console.Services;
using ApiBureau.CloudCall.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace ApiBureau.CloudCall.Api.Console;

public class Startup
{
    private IConfigurationRoot Configuration { get; }

    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure =>
        {
            configure.AddConfiguration(Configuration.GetSection("Logging"));
            configure.AddConsole();
        });
        services.AddCloudCall(Configuration);
        services.AddScoped<DataService>();
    }
}