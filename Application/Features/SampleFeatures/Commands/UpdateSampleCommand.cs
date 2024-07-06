
using Application.DTOs.SampleDTOs;
using MediatR;

namespace Application.Features.SampleFeatures.Commands
{
    public class UpdateSampleCommand () : IRequest<SampleResponse>
    {
        public UpdateSampleRequest? UpdateSampleRequest { get; set; }
        public int Id { get; set; }
    }
}
