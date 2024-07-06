
using Domain.Entities;
using MediatR;

namespace Application.Features.SampleFeatures.Queries
{
    public class GetByIdSampleQuery(): IRequest<AppSample>
    {
        public int Id { get; set; }
    }
}
