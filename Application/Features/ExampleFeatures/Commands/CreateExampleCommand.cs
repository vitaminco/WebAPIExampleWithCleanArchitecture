

using Application.DTOs.ExampleDTOs;
using MediatR;

namespace Application.Features.ExampleFeatures.Commands
{
    public class CreateExampleCommand() : IRequest<ExampleResponse>
    {
        public CreateExampleRequest? CreateExampleRequest { get; set; }
    }
}
