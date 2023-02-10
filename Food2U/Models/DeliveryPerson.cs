using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class DeliveryPerson
    {
        public int driverID { get; set; }
        public string? Name { get; set; }
        public string? Vehichle { get; set; }
        public string? Email { get; set; }
    }
}
