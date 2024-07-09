
using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using Application.Features.ExampleFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExampleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        //cách 1
        /* public async Task<ActionResult<GetAllExampleQuery>> GetAll()
         {
             return Ok(await mediator.Send(new GetAllExampleQuery()));
         }*/
        //cách 2
        public async Task<IActionResult> GetAll()
            => Ok(await mediator.Send(new GetAllExampleQuery()));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExampleResponse>> GetById(int id)
            => Ok(await mediator.Send(new GetByIdExampleQuery { Id = id }));

        [HttpPost]
        public async Task<ActionResult<ExampleResponse>> CreateExampleAsync(CreateExampleRequest createExampleRequest)
            => Ok(await mediator.Send(new CreateExampleCommand { CreateExampleRequest = createExampleRequest }));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ExampleResponse>> UpdateExmapleAsync(int id, UpdateExampleRequest updateExampleRequest)
            => Ok(await mediator.Send(new UpdateExampleCommand { Id = id, UpdateExampleRequest = updateExampleRequest }));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ExampleResponse>> DeleteExmapleAsync(int id)
            => Ok(await mediator.Send(new DeleteExampleCommand { Id = id }));

    }
}
