namespace Food2U.Models
{
    public class Items
    {
        public int itemsID { get; set; } //PK
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int localrestaurantsID {get; set;} //FK
        public LocalRestaurants LocalRestaurants {get; set;}
    }
}