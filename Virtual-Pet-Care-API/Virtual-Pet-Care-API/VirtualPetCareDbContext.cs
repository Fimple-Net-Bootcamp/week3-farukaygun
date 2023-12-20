using Microsoft.EntityFrameworkCore;
using Virtual_Pet_Care_API.Entities;

namespace Virtual_Pet_Care_API
{
	public class VirtualPetCareDbContext : DbContext
	{
		public DbSet<Activity> Activity { get; set; }
		public DbSet<Food> Food { get; set; }
		public DbSet<HealthStatus> HealthStatus { get; set; }
		public DbSet<Pet> Pet { get; set; }
		public DbSet<User> User { get; set; }



		public VirtualPetCareDbContext(DbContextOptions<VirtualPetCareDbContext> options) : base(options)
		{
		}

	}
}
