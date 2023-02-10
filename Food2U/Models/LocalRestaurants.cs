using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class LocalRestaurants
    {
        public int restaurantID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Menu { get; set; }
    }
}
