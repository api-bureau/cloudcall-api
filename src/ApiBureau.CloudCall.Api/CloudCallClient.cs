using ApiBureau.CloudCall.Api.Endpoints;

namespace ApiBureau.CloudCall.Api;

public class CloudCallClient
{
    private readonly HttpHelper _httpHelper;

    public AcccountEndpoint Accounts { get; set; }
    public CallEndpoint Calls { get; set; }

    public CloudCallClient(HttpClient client, IOptions<CloudCallSettings> settings)
    {
        _httpHelper = new HttpHelper(client, settings);

        Accounts = new AcccountEndpoint(_httpHelper);
        Calls = new CallEndpoint(_httpHelper);
    }
}
