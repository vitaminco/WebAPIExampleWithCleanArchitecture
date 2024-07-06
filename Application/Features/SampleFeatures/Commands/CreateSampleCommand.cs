

using Application.DTOs.SampleDTOs;
using MediatR;

namespace Application.Features.SampleFeatures.Commands
{
    public class CreateSampleCommand() : IRequest<SampleResponse>
    {
        public CreateSampleRequest? CreateSampleRequest { get; set; }
    }
}
