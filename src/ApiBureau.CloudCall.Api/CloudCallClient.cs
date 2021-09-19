using ApiBureau.CloudCall.Api;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiBureau.CloudCall
{
    public class CloudCallClient
    {
        private readonly CloudCallSettings _settings;
        private readonly HttpClient _client;
        private string? _accessToken;
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

        public async Task AuthenticateAsync()
        {
            var request = new PasswordTokenRequest
            {
                UserName = _settings.UserName,
                Password = _settings.Password,
            };

            var token = await _client.RequestPasswordTokenAsync(request);

            if (token is null) return;

            _accessToken = token.AccessToken;

            _client.SetBearerToken(_accessToken);
        }
    }
}
