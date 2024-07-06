
using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Queries;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.ExampleHandler.Queries
{
    public class GetAllExampleHandler : IRequestHandler<GetAllExampleQuery, List<AppExample>>
    {
        private readonly AppDbContext appDbContext;

        public GetAllExampleHandler(AppDbContext appDbContext)
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
