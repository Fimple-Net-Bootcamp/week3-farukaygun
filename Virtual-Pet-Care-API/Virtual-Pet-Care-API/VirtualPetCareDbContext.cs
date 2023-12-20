using Microsoft.EntityFrameworkCore;
using Virtual_Pet_Care_API.Entities;

namespace Virtual_Pet_Care_API
{
    public class VirtualPetCareDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<HealthStatus> HealthStatus { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }



        public VirtualPetCareDbContext(DbContextOptions<VirtualPetCareDbContext> options) : base(options)
        {
        }

    }
}
