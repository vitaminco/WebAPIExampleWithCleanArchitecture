

using Domain.Entities;
using MediatR;

namespace Application.Features.ExampleFeatures.Queries
{
    public class GetAllExampleQuery() : IRequest<List<AppExample>>
    {
    }
}
