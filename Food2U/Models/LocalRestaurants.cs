namespace Food2U.Models
{
    public class LocalRestaurants
    {
        public int localrestaurantsID { get; set; } //PK
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Menu { get; set; } = string.Empty;
    }
}