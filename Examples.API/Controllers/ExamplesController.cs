using Examples.Domain.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Examples.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExamplesController : ControllerBase
    {
        private readonly IGetExamplesUseCase getExamplesUseCase;
        private readonly IAddExampleUseCase addExampleUseCase;
        private readonly IUpdateExampleUseCase updateExampleUseCase;

        public ExamplesController(
            IGetExamplesUseCase getExamplesUseCase,
            IAddExampleUseCase addExampleUseCase,
            IUpdateExampleUseCase updateExampleUseCase)
        {
            this.getExamplesUseCase = getExamplesUseCase;
            this.addExampleUseCase = addExampleUseCase;
            this.updateExampleUseCase = updateExampleUseCase;
        }

        [HttpGet("{exampleId}")]
        public ActionResult<GetExamplesOutput> GetById(int exampleId)
        {
            var result = getExamplesUseCase.Execute(new GetExamplesInput { Id = exampleId });

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<GetExamplesOutput> Get([FromQuery]GetExamplesInput input)
        {
            var result = getExamplesUseCase.Execute(input);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Add([FromBody]AddExampleInput input)
        {
            var result = addExampleUseCase.Execute(input);

            return CreatedAtAction(nameof(GetById), new { exampleId = result.AddedExample.Id }, result.AddedExample);
        }

        [HttpPatch]
        public ActionResult<UpdateExampleOutput> Patch([FromBody]UpdateExampleInput input)
        {
            var result = updateExampleUseCase.Execute(input);

            return Ok(result);
        }
    }
}
