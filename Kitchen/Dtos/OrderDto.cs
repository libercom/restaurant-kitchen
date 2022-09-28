namespace Kitchen.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid TableId { get; set; }
        public Guid WaiterId { get; set; }
        public List<int> Items { get; set; }
        public int Priority { get; set; }
        public int MaxWait { get; set; }
        public long PickUpTime { get; set; }
    }
}
