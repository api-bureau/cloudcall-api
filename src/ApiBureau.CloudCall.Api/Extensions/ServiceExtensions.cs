using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;

namespace ApiBureau.CloudCall.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCloudCall(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudCallClient>(options => configuration.GetSection(nameof(CloudCallClient)).Bind(options));

            services.AddHttpClient<CloudCallClient>()
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(20))
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(3) }));

            return services;
        }
    }
}
