

using Application.Features.SampleFeatures.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.SampleHandler.Queries
{
    public class GetByIdSampleHandler : IRequestHandler<GetByIdSampleQuery, AppSample>
    {
        private readonly IAppDbContext appDbContext;

        public GetByIdSampleHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AppSample> Handle(GetByIdSampleQuery request, CancellationToken cancellationToken)
        => await appDbContext.Samples.FindAsync(request.Id);
    }
}
