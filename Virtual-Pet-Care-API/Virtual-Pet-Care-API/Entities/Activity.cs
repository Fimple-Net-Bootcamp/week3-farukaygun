using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Pet_Care_API.Entities
{
    public class Activity : Entity<int>
    {
        public int PetId { get; set; }
        public string ActivityName { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
    }
}
