using IdentityModel.Client;
using System.Net.Http.Json;

namespace ApiBureau.CloudCall.Api
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

        public AcccountEndpoint Accounts { get; set; }

        public CloudCallClient(IOptions<CloudCallSettings> settings, HttpClient client)
        {
            _settings = settings.Value;
            _client = client;

            _client.DefaultRequestHeaders.Add("LicenseKey", _settings.LicenseKey);

            Accounts = new AcccountEndpoint(this);
        }

        public async Task AuthenticateAsync()
        {
            var request = new PasswordTokenRequest
            {
                UserName = _settings.UserName,
                Password = _settings.Password,
                Address = _settings.LoginUrl,
                Parameters =
                {
                    { "type", "customer" }
                }
            };

            var token = await _client.RequestPasswordTokenAsync(request);

            if (token is null) return;

            // this is not working token.AccessToken;
            //_accessToken = token.AccessToken;

            _accessToken = token.Json.GetProperty("data").TryGetString("token");

            _client.SetBearerToken(_accessToken);
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            await CheckConnectionAsync();

            return await _client.GetFromJsonAsync<T>($"{_settings.BaseUrl}/customers/{_settings.UserName}/{url}");
        }

        private async Task CheckConnectionAsync()
        {
            //ToDo Check Expiry Time

            if (_accessToken == null)
            {
                await AuthenticateAsync();
            }
        }
    }
}
