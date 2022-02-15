using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private static List<Animal> animals = new List<Animal> {

                new Animal {
                    id = 1,
                    breedName = "Golden Retriever",
                    hairStyle = "Long",
                    size = "Medium"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> getAnimalById(int id)
        {
            var animal = animals.Find(x => x.id == id);
            if(animal == null)
            {
                return BadRequest("Animal not found");
            }
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<List<Animal>>> addAnimal(Animal animal)
        {
            animals.Add(animal);
            return Ok(animals);
        }

        [HttpPut]
        public async Task<ActionResult<List<Animal>>> modifyAnimal(Animal animal)
        {
            var updateAnimal = animals.Find(x => x.id == animal.id);
            if (animal == null)
            {
                return BadRequest("Animal not found");
            }
            updateAnimal.breedName = animal.breedName;
            updateAnimal.size = animal.size;
            updateAnimal.hairStyle = animal.hairStyle;

            return Ok(animals);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Animal>>> deleteAnimal(int id)
        {
            var animal = animals.Find(x => x.id == id);
            if (animal == null)
            {
                return BadRequest("Animal not found");
            }
            animals.Remove(animal);
            return Ok(animals);
        }
    }
}
