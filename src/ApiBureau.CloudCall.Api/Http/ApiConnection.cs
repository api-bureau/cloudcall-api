using IdentityModel.Client;
using System.Net.Http.Json;

namespace ApiBureau.CloudCall.Api.Http;

public class ApiConnection
{
    private readonly HttpClient _client;
    private readonly CloudCallSettings _settings;
    private string? _accessToken;
    private const int _pageSize = 1000;
    //private DateTime? _tokenExpireTime;
    //private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    //{
    //    PropertyNameCaseInsensitive = true,
    //};

    public ApiConnection(HttpClient httpClient, IOptions<CloudCallSettings> settings)
    {
        _settings = settings.Value;
        _client = httpClient;

        _client.DefaultRequestHeaders.Add("LicenseKey", _settings.LicenseKey);
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

    //public async Task<T?> GetCallsAsync<T>(string url)
    //{
    //    await CheckConnectionAsync();

    //    return await _client.GetFromJsonAsync<T>($"{_settings.BaseUrl}/customers/{_settings.UserName}/{url}&leg=c");
    //}

    private async Task CheckConnectionAsync()
    {
        //ToDo Check Expiry Time

        if (_accessToken == null)
            await AuthenticateAsync();
    }
}
