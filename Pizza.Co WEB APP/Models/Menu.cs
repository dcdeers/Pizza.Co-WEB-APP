using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Co_WEB_APP.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
