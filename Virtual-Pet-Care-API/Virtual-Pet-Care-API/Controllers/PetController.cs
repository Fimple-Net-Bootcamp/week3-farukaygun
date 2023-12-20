using Microsoft.AspNetCore.Mvc;
using Virtual_Pet_Care_API.Entities;

namespace Virtual_Pet_Care_API.Controllers
{
	[ApiController]
	[Route("api/v1/pets")]
	public class PetController : ControllerBase
	{
		private readonly VirtualPetCareDbContext context;

		public PetController(VirtualPetCareDbContext context)
		{
			this.context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Create(Pet pet)
		{
			try
			{
				await context.Pet.AddAsync(pet);
				await context.SaveChangesAsync();

				return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, $"Internal server error.");
			}
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var pets = context.Pet.ToList();

				if (pets is null)
					return NotFound();

				return Ok(pets);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpGet("/pet/{id}")]
		public IActionResult GetById(int id)
		{
			try
			{
				var pet = context.Pet.Where(pet => pet.Id == id).FirstOrDefault();

				if (pet is null)
					return NotFound();

				return Ok(pet);
			}
			catch (Exception e)
			{

				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpPut("/pet/{id}")]
		public async Task<IActionResult> Update(int id, Pet pet)
		{
			try
			{
				var petToUpdate = context.Pet.Where(pet => pet.Id == id).FirstOrDefault();

				if (petToUpdate is null)
					return NotFound();

				petToUpdate.Name = pet.Name;
				petToUpdate.Age = pet.Age;
				petToUpdate.Species = pet.Species;

				await context.SaveChangesAsync();

				return Ok(petToUpdate);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}
