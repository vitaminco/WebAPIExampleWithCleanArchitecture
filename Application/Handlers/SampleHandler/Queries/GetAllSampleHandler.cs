

using Application.Features.SampleFeatures.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.SampleHandler.Queries
{
    public class GetAllSampleHandler : IRequestHandler<GetAllSampleQuery, List<AppSample>>
    {
        private readonly IAppDbContext appDbContext;

        public GetAllSampleHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<AppSample>> Handle(GetAllSampleQuery request, CancellationToken cancellationToken)
        => await appDbContext.Samples.ToListAsync();
    }
}
