

using Application.Features.SampleFeatures.Queries;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.SampleHandler.Queries
{
    public class GetByIdSampleHandler : IRequestHandler<GetByIdSampleQuery, AppSample>
    {
        private readonly AppDbContext appDbContext;
        public GetByIdSampleHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AppSample> Handle(GetByIdSampleQuery request, CancellationToken cancellationToken)
        {
            var find = await appDbContext.Samples.FindAsync(request.Id);
            return find;
        }
    }
}
