using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ApiBureau.CloudCall.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCloudCall(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CloudCallSettings>(options => configuration.GetSection(nameof(CloudCallSettings)).Bind(options));

        services.AddHttpClient<ApiConnection>()
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));

        services.AddSingleton<ICloudCallClient, CloudCallClient>();

        return services;
    }
}