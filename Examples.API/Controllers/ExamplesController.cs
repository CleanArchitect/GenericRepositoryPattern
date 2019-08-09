using Examples.Domain.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Examples.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamplesController : ControllerBase
    {
        private readonly IHubContext<ExampleHub, IExampleHub> exampleHub;

        public ExamplesController(IHubContext<ExampleHub, IExampleHub> exampleHub)
        {
            this.exampleHub = exampleHub;
        }

        [HttpGet("{exampleId}")]
        public async Task<IActionResult> GetById(int exampleId, [FromServices]IGetExamplesUseCase getExamplesUseCase)
        {
            var result = await getExamplesUseCase.ExecuteAsync(new GetExamplesInput { Id = exampleId });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetExamplesInput input, [FromServices]IGetExamplesUseCase getExamplesUseCase)
        {
            var result = await getExamplesUseCase.ExecuteAsync(input);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddExampleInput input, [FromServices]IAddExampleUseCase addExampleUseCase)
        {
            var result = await addExampleUseCase.ExecuteAsync(input);

            await exampleHub.Clients.All.SendClientExamplesUpdate();

            return CreatedAtAction(nameof(GetById), new { exampleId = result.AddedExample.Id }, result.AddedExample);
        }

        [HttpPatch("{exampleId}")]
        public async Task<IActionResult> Patch(int exampleId, [FromBody]UpdateExampleInput input, [FromServices]IUpdateExampleUseCase updateExampleUseCase)
        {
            input.Id = exampleId;

            var result = await updateExampleUseCase.ExecuteAsync(input);

            await exampleHub.Clients.All.SendClientExamplesUpdate();

            return Ok(result);
        }
    }
}
