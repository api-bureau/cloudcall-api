using ApiBureau.CloudCall.Api.Endpoints;

namespace ApiBureau.CloudCall.Api;

public class CloudCallClient
{
    private readonly ApiConnection _apiConnection;

    public AcccountEndpoint Accounts { get; }
    public CallEndpoint Calls { get; }

    public CloudCallClient(HttpClient client, IOptions<CloudCallSettings> settings)
    {
        _apiConnection = new ApiConnection(client, settings);

        Accounts = new AcccountEndpoint(_apiConnection);
        Calls = new CallEndpoint(_apiConnection);
    }
}
