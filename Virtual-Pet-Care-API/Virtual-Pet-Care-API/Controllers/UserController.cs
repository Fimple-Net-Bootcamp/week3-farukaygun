using Microsoft.AspNetCore.Mvc;

namespace Virtual_Pet_Care_API.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class UserController : ControllerBase
	{
		private readonly VirtualPetCareDbContext context;

		public UserController(VirtualPetCareDbContext context)
		{
			this.context = context;
		}

		//post user
		[HttpPost]
		public async Task<IActionResult> Create(User user)
		{
			try
			{
				await context.Users.AddAsync(user);
				await context.SaveChangesAsync();

				return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, $"Internal server error.");
			}
		}

		[HttpGet("/user/{id}")]
		public IActionResult GetById(int id)
		{
			try
			{
				var user = context.Users.Where(user => user.Id == id).FirstOrDefault();

				if (user is null)
					return NotFound();
				
				return Ok(user);
			}
			catch (Exception e)
			{

				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}
