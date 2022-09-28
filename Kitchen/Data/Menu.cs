using Kitchen.Models;
using Newtonsoft.Json;

namespace Kitchen.Data
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }

        public Menu()
        {
            LoadMenu();
        }

        public void LoadMenu()
        {
            using (StreamReader r = new StreamReader("./Data/Source/menuItems.json"))
            {
                string json = r.ReadToEnd();

                MenuItems = JsonConvert.DeserializeObject<List<MenuItem>>(json);
            }
        }
    }
}
