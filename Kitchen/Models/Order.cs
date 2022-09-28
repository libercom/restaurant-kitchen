using Kitchen.Constants;
using Kitchen.Dtos;

namespace Kitchen.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid WaiterId { get; set; }
        public Guid TableId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int MaxWait { get; set; }
        public int Priority { get; set; }
        public long PickUpTime { get; set; }
        public OrderStatus Status { get; set; }

        public Order(OrderDto orderDto)
        {
            OrderId = orderDto.OrderId;
            WaiterId = orderDto.WaiterId;
            TableId = orderDto.TableId;
            MaxWait = orderDto.MaxWait;
            Priority = orderDto.Priority;
            PickUpTime = orderDto.PickUpTime;
            Status = OrderStatus.FreeToTake;
        }

        public bool CheckIfOrderFinished(Guid orderId, Guid orderItemId)
        {
            var orderItem = OrderItems.FirstOrDefault(x => x.OrderItemId == orderItemId);

            orderItem.Completed = true;

            var orderCompleted = OrderItems.All(x => x.Completed == true);

            return orderCompleted;
        }
    }
}
