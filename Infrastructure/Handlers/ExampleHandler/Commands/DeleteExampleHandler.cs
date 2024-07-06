

using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.ExampleHandler.Commands
{
    public class DeleteExampleHandler : IRequestHandler<DeleteExampleCommand, ExampleResponse>
    {
        private readonly AppDbContext appDbContext;

        public DeleteExampleHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ExampleResponse> Handle(DeleteExampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await appDbContext.Examples.FindAsync(request.Id);
                if (res is null)
                {
                    return new ExampleResponse(false, "Vui lòng nhập Id");
                }

                appDbContext.Examples.Remove(res);
                await appDbContext.SaveChangesAsync();
                return new ExampleResponse(true, "Xóa thành công");
            }
            catch (Exception ex)
            {
                return new ExampleResponse(false, "Lỗi");
            }
        }
    }
}
