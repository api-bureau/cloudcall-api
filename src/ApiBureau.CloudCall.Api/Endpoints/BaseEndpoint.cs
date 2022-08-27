namespace ApiBureau.CloudCall.Api.Endpoints;

public class BaseEndpoint
{
    protected ApiConnection ApiConnection { get; }

    public BaseEndpoint(ApiConnection apiConnection) => ApiConnection = apiConnection;
}
