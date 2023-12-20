namespace Virtual_Pet_Care_API.Entities
{
    public class Food : Entity<int>
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }
    }
}
