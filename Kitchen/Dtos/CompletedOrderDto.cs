using Kitchen.Models;

namespace Kitchen.Dtos
{
    public class CompletedOrderDto
    {
        public Guid OrderId { get; set; }
        public Guid TableId { get; set; }
        public Guid WaiterId { get; set; }
        public List<int> Items { get; set; }
        public int Priority { get; set; }
        public int MaxWait { get; set; }
        public long PickUpTime { get; set; }
        public long CookTime { get; set; }

        public CompletedOrderDto(Order order)
        {
            OrderId = order.OrderId;
            TableId = order.TableId;
            WaiterId = order.WaiterId;
            Items = order.OrderItems.Select(x => x.MenuItemId).ToList();
            Priority = order.Priority;
            MaxWait = order.MaxWait;
            PickUpTime = order.PickUpTime;
        }
    }
}
