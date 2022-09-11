namespace ApiBureau.CloudCall.Api.Endpoints;

public class CallEndpoint : BaseEndpoint
{
    private const string Endpoint = "calls";

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

    /// <summary>
    /// Returns calls in the date range, step by minutes. This can be useful if you are assuming lots of data. You can fetch into multiple API calls e.g., daily, hourly
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to">This is might be extended if used with stepInMinutes</param>
    /// <param name="stepInMinutes"></param>
    /// <returns></returns>
    public async Task<List<CallDto>> GetAsync(DateTime from, DateTime to, int? stepInMinutes)
    {
        if (stepInMinutes is null || stepInMinutes == 0 || (to - from).TotalMinutes <= stepInMinutes) return await GetAsync(from, to);

        List<CallDto> calls = new();

        var step = stepInMinutes.Value;

        while (from <= to)
        {
            calls.AddRange(await GetAsync(from, from.AddMinutes(step)));

            from = from.AddMinutes(step);
        }

        return calls;
    }
}