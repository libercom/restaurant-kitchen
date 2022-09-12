using System.Text;

namespace Kitchen.Services
{
    public class KitchenService : BackgroundService
    {
        private readonly ILogger<KitchenService> _logger;
        private readonly string _apiEndpoint;

        public KitchenService(ILogger<KitchenService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _apiEndpoint = configuration.GetSection("DinningHallEndpoint").Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new HttpClient();

                await Task.Delay(3000);

                await client.PostAsync(_apiEndpoint, new StringContent("", Encoding.UTF8, "application/json"));
            }
        }
    }
}
