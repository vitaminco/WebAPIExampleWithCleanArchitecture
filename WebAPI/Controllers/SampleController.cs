using Application.DTOs.SampleDTOs;
using Application.Features.SampleFeatures.Commands;
using Application.Features.SampleFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IMediator mediator;

        public SampleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<SampleResponse>> GetAll()
            => Ok(await mediator.Send(new GetAllSampleQuery()));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SampleResponse>> GetById(int id)
            => Ok(await mediator.Send(new GetByIdSampleQuery { Id = id }));

        [HttpPost]
        public async Task<ActionResult<SampleResponse>> CreateSampleAsync(CreateSampleRequest createSampleRequest)
            => Ok(await mediator.Send(new CreateSampleCommand { CreateSampleRequest = createSampleRequest }));


        [HttpPut("{id:int}")]
        public async Task<ActionResult<SampleResponse>> UpdateSampleAsync(int id, UpdateSampleRequest updateSampleRequest)
            => Ok(await mediator.Send(new UpdateSampleCommand { Id = id, UpdateSampleRequest = updateSampleRequest }));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SampleResponse>> Delete(int id)
            => Ok(await mediator.Send(new DeleteSampleCommand { Id = id }));
    }
}
