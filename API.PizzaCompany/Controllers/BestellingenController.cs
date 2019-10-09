using Domain.PizzaCompany;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.PizzaCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellingenController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> BekijkBestelling(
            [FromRoute]int id, 
            [FromServices]IBestellingBekijkenUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(new BestellingBekijkenInput(id));

            return Ok(result.Bestelling);
        }

        [HttpPost]
        public async Task<IActionResult> PlaatsBestelling(
            [FromServices]IBestellingPlaatsenUseCase useCase, 
            [FromBody]BestellingPlaatsenInput input)
        {
            var result = await useCase.ExecuteAsync(input);

            return CreatedAtAction(nameof(BekijkBestelling), new { id = result.NieuweBestelling.Id }, result.NieuweBestelling);
        }

        [HttpPatch("{id}/statuswijzigen")]
        public async Task<IActionResult> StatusWijzigen(
            [FromRoute]int id, 
            [FromServices]IStatusBestellingWijzigenUseCase useCase, 
            [FromBody]StatusBestellingWijzigenInput input)
        {
            var result = await useCase.ExecuteAsync(input);

            return Ok(result);
        }
    }
}
