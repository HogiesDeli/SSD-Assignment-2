using System.ComponentModel.DataAnnotations;

namespace Food2U.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public decimal Total { get; set; }
    }
}

