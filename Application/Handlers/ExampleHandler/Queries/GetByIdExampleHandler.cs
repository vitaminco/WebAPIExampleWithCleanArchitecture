
using Application.Features.ExampleFeatures.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.ExampleHandler.Queries
{
    public class GetByIdExampleHandler : IRequestHandler<GetByIdExampleQuery, AppExample>
    {
        private readonly IAppDbContext appDbContext;

        public GetByIdExampleHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AppExample> Handle(GetByIdExampleQuery request, CancellationToken cancellationToken)
        {
            //tìm Id trong bảng
            var res = await appDbContext.Examples.FindAsync(request.Id);

            return res;
        }
    }
}
