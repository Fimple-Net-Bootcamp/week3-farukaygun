using Microsoft.AspNetCore.Mvc;
using Virtual_Pet_Care_API.Entities;

namespace Virtual_Pet_Care_API.Controllers
{
	[ApiController]
	[Route("api/v1/activities")]
	public class ActivityController : ControllerBase
	{
		private readonly VirtualPetCareDbContext context;

		public ActivityController(VirtualPetCareDbContext context)
		{
			this.context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Create(Activity activity)
		{
			try
			{
				await context.Activities.AddAsync(activity);
				await context.SaveChangesAsync();

				return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, $"Internal server error.");
			}
		}

		[HttpGet("{petId}")]
		public IActionResult GetById(int petId)
		{
			try
			{
				var activity = context.Activities.Where(activity => activity.PetId == petId).FirstOrDefault();

				if (activity is null)
					return NotFound();

				return Ok(activity);
			}
			catch (Exception e)
			{

				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}
