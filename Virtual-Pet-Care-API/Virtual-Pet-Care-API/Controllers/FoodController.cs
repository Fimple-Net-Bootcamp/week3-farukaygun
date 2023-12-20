using Microsoft.AspNetCore.Mvc;

namespace Virtual_Pet_Care_API.Controllers
{
	[ApiController]
	[Route("api/v1/foods")]
	public class FoodController : ControllerBase
	{
		private readonly VirtualPetCareDbContext context;

		public FoodController(VirtualPetCareDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var foods = context.Food.ToList();

				if (foods is null)
					return NotFound();

				return Ok(foods);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}

		//[HttpPost("pet/{petId}")]
		//public async Task<IActionResult> Create(int petId, [FromBody] Food food)
		//{
		//	try
		//	{
		//		var pet = context.Pets.Where(pet => pet.Id == petId).FirstOrDefault();

		//		if (pet is null)
		//			return NotFound();

		//		food.PetId = petId;

		//		await context.Foods.AddAsync(food);
		//		await context.SaveChangesAsync();

		//		return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
		//	}
		//	catch (Exception e)
		//	{
		//		Console.WriteLine($"{e.Message}");
		//		return StatusCode(500, $"Internal server error.");
		//	}
		//}
	}
}
