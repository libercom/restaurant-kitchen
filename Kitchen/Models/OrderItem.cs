using Kitchen.Constants;

namespace Kitchen.Models
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int PreparationTime { get; set; }
        public int Complexity { get; set; }
        public string CookingApparatus { get; set; }
        public bool Completed { get; set; }

        public OrderItem(MenuItem menuItem)
        {
            OrderItemId = Guid.NewGuid();
            MenuItemId = menuItem.MenuItemId;
            PreparationTime = menuItem.PreparationTime;
            Complexity = menuItem.Complexity;
            CookingApparatus = menuItem.CookingApparatus;
            Completed = false;
        }
    }
}
