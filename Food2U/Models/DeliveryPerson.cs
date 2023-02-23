namespace Food2U.Models
{
    public class DeliveryPerson
    {
        public int deliverypersonID { get; set; } //PK
        public string Name { get; set; } = string.Empty;
        public string Vehichle { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}