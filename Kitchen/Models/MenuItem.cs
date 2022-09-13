using Kitchen.Constants;

namespace Kitchen.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int PreparationTime { get; set; }
        public int Complexity { get; set; }
        public AparatusType Aparatus { get; set; }
    }
}
