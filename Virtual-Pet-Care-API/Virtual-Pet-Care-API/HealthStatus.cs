using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Pet_Care_API
{
	public class HealthStatus : Entity<int>
	{
		public int PetId { get; set; }
		public DateTime VetExaminationDate { get; set; }
		public DateTime VaccinationDate { get; set; }
		public string VaccinationType { get; set; }
		[ForeignKey("PetId")]
		public Pet Pet { get; set; }
	}
}
