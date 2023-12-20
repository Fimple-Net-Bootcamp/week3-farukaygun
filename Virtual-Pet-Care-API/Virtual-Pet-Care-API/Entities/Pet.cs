namespace Virtual_Pet_Care_API.Entities
{
	public class Pet : Entity<int>
	{
		public int UserId { get; set; }
		public string Species { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		//public List<HealthStatus> HealthStatus { get; set; } = new();
		//public List<Activity> Activities { get; set; } = new();
	}
}
