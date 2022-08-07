using Microsoft.Extensions.Logging;

namespace ApiBureau.CloudCall.Api.Console.Services
{
    public class DataService
    {
        private readonly CloudCallClient _client;
        private readonly ILogger<DataService> _logger;

        public DataService(CloudCallClient client, ILogger<DataService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task RunAsync()
        {

            //await _client.AuthenticateAsync();

            var accounts = await _client.Accounts.GetAsync();
            var items = await _client.Calls.GetAsync(DateTime.Now.AddDays(-2), DateTime.Now);
            var items2 = await _client.Calls.GetAsync(DateTime.Now.AddDays(-2), DateTime.Now, 60 * 24);

            _logger.LogInformation("Accounts: {0}, Items: {1}, Items: {1}", accounts.Count, items.Count, items2.Count);

            //var dto = await _client.Skills.GetStatusAsync();

            //if (dto.IsSuccess)
            //{
            //    var status = dto.Data!;

            //    _logger.LogInformation(status.Healthy.ToString());
            //    _logger.LogInformation(status.Message);
            //}
        }
    }
}
