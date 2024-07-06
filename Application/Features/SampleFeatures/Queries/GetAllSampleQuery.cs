

using Domain.Entities;
using MediatR;

namespace Application.Features.SampleFeatures.Queries
{
    public class GetAllSampleQuery () : IRequest<List<AppSample>>{}
}
