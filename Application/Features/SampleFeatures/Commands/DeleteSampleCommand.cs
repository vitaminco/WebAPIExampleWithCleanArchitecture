

using Application.DTOs.SampleDTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.SampleFeatures.Commands
{
    public class DeleteSampleCommand():IRequest<SampleResponse>
    {
        public int Id { get; set; }
    }
}
