using Kitchen.Constants;
using Kitchen.Data;
using Kitchen.Dtos;
using Kitchen.Models;
using Newtonsoft.Json;
using System.Text;

namespace Kitchen.Services
{
    public class KitchenService : IKitchenService
    {
        private readonly ILogger<KitchenService> _logger;
        private readonly string _apiEndpoint;
        private readonly Menu _menu;

        public List<Order> OrderList { get; set; }
        public List<Cook> Cooks { get; set; }

        public KitchenService(Menu menu, ILogger<KitchenService> logger, ILogger<Cook> cookLogger, IConfiguration configuration)
        {
            _logger = logger;
            _menu = menu;
            _apiEndpoint = configuration.GetSection("DinningHallEndpoint").Value;

            OrderList = new List<Order>();

            Cooks = new List<Cook>()
            {
                new Cook(cookLogger, this) {CookId = 1, Rank = 3},
                new Cook(cookLogger, this) {CookId = 2, Rank = 3},
                new Cook(cookLogger, this) {CookId = 3, Rank = 3},
            };

            ExecuteAsync(CancellationToken.None);
        }

        public async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1);
                // todo
            }
        }

        public void TakeOrder(OrderDto orderDto)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in orderDto.Items)
            {
                orderItems.Add(new OrderItem(_menu.MenuItems[item - 1]) { OrderId = orderDto.OrderId });
            }

            var order = new Order(orderDto) { OrderItems = orderItems };

            OrderList.Add(order);

            AssignCook(order);
        }

        public async Task DistributeOrder(Order order)
        {
            var client = new HttpClient();
            var completedOrderDto = new CompletedOrderDto(order) 
            { 
                CookTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - order.PickUpTime
            };
            var serializedCompletedOrderDto = JsonConvert.SerializeObject(completedOrderDto);

            OrderList.Remove(order);

            await client.PostAsync(_apiEndpoint, new StringContent(serializedCompletedOrderDto, Encoding.UTF8, "application/json"));
        }

        public void AssignCook(Order order)
        {
            var orderComplexity = order.OrderItems.MaxBy(x => x.Complexity)?.Complexity;

            foreach (var cook in Cooks)
            {
                if (cook.Rank >= orderComplexity && cook.Status == CookStatus.Free)
                {
                    cook.TakeOrder(order);
                    break;
                }
            }
        }
    }
}
