using ApiBureau.CloudCall.Api.Console.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBureau.CloudCall.Api.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            var startup = new Startup();

            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var dataService = serviceProvider.GetService<DataService>()
                ?? throw new ArgumentNullException($"{nameof(DataService)} cannot be null");


            await dataService.RunAsync();
        }
    }
}
