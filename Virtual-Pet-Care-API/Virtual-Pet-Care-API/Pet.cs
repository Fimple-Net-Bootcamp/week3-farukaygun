using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Pet_Care_API
{
	public class Pet : Entity<int>
	{
		public int UserId { get; set; }
		public string Species { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string Color { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }
		public List<HealthStatus> HealthStatusList { get; set; }
		public List<Activity> Activities { get; set; }
	}
}
