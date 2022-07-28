namespace ApiBureau.CloudCall.Api.Endpoints;

public class AcccountEndpoint : BaseEndpoint
{
    private const string Endpoint = "/accounts";

    public AcccountEndpoint(ApiConnection apiConnection) : base(apiConnection) { }

    /// <summary>
    /// Return all accounts
    /// </summary>
    /// <returns></returns>
    public async Task<List<AccountDto>> GetAsync()
            => await ApiConnection.GetAsync<List<AccountDto>>(Endpoint) ?? new();
}