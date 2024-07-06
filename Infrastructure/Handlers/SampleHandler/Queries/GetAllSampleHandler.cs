

using Application.Features.SampleFeatures.Queries;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.SampleHandler.Queries
{
    public class GetAllSampleHandler : IRequestHandler<GetAllSampleQuery, List<AppSample>>
    {
        private readonly AppDbContext appDbContext;

        public GetAllSampleHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<AppSample>> Handle(GetAllSampleQuery request, CancellationToken cancellationToken)
        {
            var res = await appDbContext.Samples.ToListAsync();
            return res;
        }
    }
}
