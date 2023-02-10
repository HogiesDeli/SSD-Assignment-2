using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class Items
    {
        public int itemID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}

