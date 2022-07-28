namespace ApiBureau.CloudCall.Api.Endpoints;

public class BaseEndpoint
{
    protected ApiConnection ApiConnection { get; private set; }

    public BaseEndpoint(ApiConnection apiConnection) => ApiConnection = apiConnection;
}
