using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class Shoppers
    {
        [Key]
        public int shopperID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

    }
}

