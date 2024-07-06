

using Application.DTOs.ExampleDTOs;
using MediatR;

namespace Application.Features.ExampleFeatures.Commands
{
    public class UpdateExampleCommand() : IRequest<ExampleResponse>
    {
        public UpdateExampleRequest? UpdateExampleRequest { get; set; }
        public int Id { get; set; }
    }
}
