

using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Queries;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Handlers.ExampleHandler.Queries
{
    public class GetByIdExampleHandler : IRequestHandler<GetByIdExampleQuery, AppExample>
    {
        private readonly AppDbContext appDbContext;
        private readonly ILogger<GetByIdExampleQuery> logger;

        public GetByIdExampleHandler(AppDbContext appDbContext, ILogger<GetByIdExampleQuery> logger)
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }
        public async Task<AppExample> Handle(GetByIdExampleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //tìm Id trong bảng
                var res = await appDbContext.Examples.FindAsync(request.Id);
                if (res == null)
                {
                    logger.LogInformation("Không tìm thấy");
                }
                return res;
            }
            catch (Exception ex)
            {
                logger.LogError("Lỗi");
                return null;
            }
        }
    }
}
