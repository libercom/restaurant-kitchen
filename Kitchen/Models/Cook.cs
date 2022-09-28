using Kitchen.Constants;
using Kitchen.Services;

namespace Kitchen.Models
{
    public class Cook
    {
        private readonly ILogger<Cook> _logger;
        private readonly IKitchenService _kitchenService;

        public int CookId { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public CookStatus Status { get; set; }
        public int Rank { get; set; }
        public int Proficiency { get; set; }

        public Cook(ILogger<Cook> logger, IKitchenService kitchenService)
        {
            _logger = logger;
            _kitchenService = kitchenService;
        }

        public void TakeOrder(Order order)
        {
            _logger.LogInformation($"Cook {CookId}: Took the order with id {order.OrderId}");

            Status = CookStatus.Cooking;

            order.OrderItems.ForEach(orderItem =>
            {
                Task.Run(() =>
                {
                    CookOrderItem(order, orderItem);
                });
            });
        }

        public async Task CookOrderItem(Order order, OrderItem orderItem)
        {
            await Task.Delay(orderItem.PreparationTime * 100);

            var finished = order.CheckIfOrderFinished(orderItem.OrderId, orderItem.OrderItemId);

            if (finished)
            {
                Status = CookStatus.Free;
                _kitchenService.DistributeOrder(order);

                _logger.LogInformation($"Cook {CookId}: Finished the order with id {order.OrderId}");
            }
        }
    }
}
