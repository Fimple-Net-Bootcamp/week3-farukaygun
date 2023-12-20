namespace Virtual_Pet_Care_API.Entities
{
    public class User : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
