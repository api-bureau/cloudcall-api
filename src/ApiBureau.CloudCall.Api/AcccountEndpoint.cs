using ApiBureau.CloudCall.Api.Dtos;

namespace ApiBureau.CloudCall.Api;

public class AcccountEndpoint
{
    private const string Endpoint = "/accounts";
    private readonly CloudCallClient _client;

    public AcccountEndpoint(CloudCallClient client) => _client = client;

    public async Task<List<AccountDto>> GetAsync()
            => await _client.GetAsync<List<AccountDto>>(Endpoint) ?? new();
}
