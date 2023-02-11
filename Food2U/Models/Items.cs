using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class Items
    {
        [Key]
        public int itemID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}

