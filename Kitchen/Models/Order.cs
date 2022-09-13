namespace Kitchen.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Priority { get; set; }
        public List<int> Items { get; set; }
        public int MaxWait { get; set; }
    }
}
