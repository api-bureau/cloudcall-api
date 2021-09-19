using ApiBureau.CloudCall.Api;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace ApiBureau.CloudCall
{
    public class CloudCallClient
    {
        private readonly CloudCallSettings _settings;
        private readonly HttpClient _client;
        //private string? _accessToken;
        //private DateTime? _tokenExpireTime;
        private static JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public CloudCallClient(IOptions<CloudCallSettings> settings, HttpClient client)
        {
            _settings = settings.Value;
            _client = client;
        }
    }
}
