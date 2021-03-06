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

            _logger.LogInformation("Items: {0}", accounts.Count());

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
