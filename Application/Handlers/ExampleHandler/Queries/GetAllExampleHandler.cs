

using Application.Features.ExampleFeatures.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.ExampleHandler.Queries
{
    public class GetAllExampleHandler : IRequestHandler<GetAllExampleQuery, List<AppExample>>
    {
        private readonly IAppDbContext appDbContext;

        public GetAllExampleHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<AppExample>> Handle(GetAllExampleQuery request, CancellationToken cancellationToken)
        {
            var res = await appDbContext.Examples.ToListAsync();
            return res;
        }
    }
}