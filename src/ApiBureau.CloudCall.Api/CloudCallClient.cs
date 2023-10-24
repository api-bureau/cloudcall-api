using ApiBureau.CloudCall.Api.Endpoints;

namespace ApiBureau.CloudCall.Api;

public class CloudCallClient
{
    private readonly ApiConnection _apiConnection;

    public AccountEndpoint Accounts { get; }
    public CallEndpoint Calls { get; }

    public CloudCallClient(HttpClient client, IOptions<CloudCallSettings> settings)
    {
        _apiConnection = new ApiConnection(client, settings);

        Accounts = new AccountEndpoint(_apiConnection);
        Calls = new CallEndpoint(_apiConnection);
    }
}