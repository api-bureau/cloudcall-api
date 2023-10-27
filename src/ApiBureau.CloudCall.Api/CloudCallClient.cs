namespace ApiBureau.CloudCall.Api;

public class CloudCallClient : ICloudCallClient
{
    public AccountEndpoint Accounts { get; }
    public CallEndpoint Calls { get; }

    public CloudCallClient(ApiConnection apiConnection)
    {
        Accounts = new AccountEndpoint(apiConnection);
        Calls = new CallEndpoint(apiConnection);
    }
}