namespace ApiBureau.CloudCall.Api.Endpoints;

public class CallEndpoint
{
    private const string Endpoint = "/calls";
    private readonly HttpHelper _helper;

    public CallEndpoint(HttpHelper helper) => _helper = helper;

    public async Task<List<CallDto>> GetAsync(DateTime from, DateTime to)
            => await _helper.GetCallsAsync<List<CallDto>>($"{Endpoint}?from={from:u}&to={to:u}") ?? new();
}