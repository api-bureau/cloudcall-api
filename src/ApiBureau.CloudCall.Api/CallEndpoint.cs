using ApiBureau.CloudCall.Api.Dtos;

namespace ApiBureau.CloudCall.Api;

public class CallEndpoint
{
    private const string Endpoint = "/calls";
    private readonly CloudCallClient _client;

    public CallEndpoint(CloudCallClient client) => _client = client;

    public async Task<List<CallDto>> GetAsync(DateTime from, DateTime to)
            => await _client.GetCallsAsync<List<CallDto>>($"{Endpoint}?from={from:u}&to={to:u}") ?? new();
}