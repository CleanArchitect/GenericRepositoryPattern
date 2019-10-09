using Domain.PizzaCompany;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.PizzaCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet("menu")]
        public async Task<IActionResult> Menu(
            [FromServices]IPizzaMenuBekijkenUseCase useCase, 
            [FromQuery]PizzaMenuBekijkenInput input)
        {
            var result = await useCase.ExecuteAsync(input);

            return Ok(result.PizzaKeuzes);
        }
    }
}
