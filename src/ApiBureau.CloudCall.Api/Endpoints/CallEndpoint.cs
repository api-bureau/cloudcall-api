namespace ApiBureau.CloudCall.Api.Endpoints;

public class CallEndpoint : BaseEndpoint
{
    private const string Endpoint = "/calls";

    // This should merge certain calls together
    private const string LegC = "&leg=c";

    public CallEndpoint(ApiConnection apiConnection) : base(apiConnection) { }

    /// <summary>
    /// Returns calls in the date range
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public async Task<List<CallDto>> GetAsync(DateTime from, DateTime to)
            => await ApiConnection.GetAsync<List<CallDto>>($"{Endpoint}?from={from:u}&to={to:u}{LegC}") ?? new();
}