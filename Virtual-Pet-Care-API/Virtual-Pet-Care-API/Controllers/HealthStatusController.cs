using Microsoft.AspNetCore.Mvc;

namespace Virtual_Pet_Care_API.Controllers
{
	[ApiController]
	[Route("api/v1/healthstatus")]
	public class HealthStatusController : ControllerBase
	{
		private readonly VirtualPetCareDbContext context;

		public HealthStatusController(VirtualPetCareDbContext context)
		{
			this.context = context;
		}

		[HttpGet("{petId}")]
		public IActionResult GetHealthStatus(int petId)
		{
			try
			{
				var healthStatus = context.HealthStatus.Where(healthStatus => healthStatus.PetId == petId).FirstOrDefault();

				if (healthStatus is null)
					return NotFound();

				return Ok(healthStatus);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpPatch("{petId}")]
		public async Task<IActionResult> UpdateHealthStatus(int petId, [FromBody] HealthStatus healthStatus)
		{
			try
			{
				var healthStatusToUpdate = context.HealthStatus.Where(healthStatus => healthStatus.PetId == petId).FirstOrDefault();

				if (healthStatusToUpdate is null)
					return NotFound();

				healthStatusToUpdate.VaccinationDate = healthStatus.VaccinationDate;
				healthStatusToUpdate.VaccinationType = healthStatus.VaccinationType;
				healthStatusToUpdate.VetExaminationDate = healthStatus.VetExaminationDate;

				await context.SaveChangesAsync();

				return Ok(healthStatusToUpdate);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}
