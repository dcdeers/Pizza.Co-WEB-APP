using System.ComponentModel.DataAnnotations;

namespace Pizza.Co_WEB_APP.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
