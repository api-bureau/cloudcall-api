namespace ApiBureau.CloudCall.Api.Endpoints;

public class AcccountEndpoint
{
    private const string Endpoint = "/accounts";
    private readonly HttpHelper _helper;

    public AcccountEndpoint(HttpHelper helper) => _helper = helper;

    public async Task<List<AccountDto>> GetAsync()
            => await _helper.GetAsync<List<AccountDto>>(Endpoint) ?? new();
}