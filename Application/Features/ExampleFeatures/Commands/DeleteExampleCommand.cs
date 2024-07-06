

using Application.DTOs.ExampleDTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExampleFeatures.Commands
{
    public class DeleteExampleCommand() : IRequest<ExampleResponse>
    {
        public int Id { get; set; }
    }
}
