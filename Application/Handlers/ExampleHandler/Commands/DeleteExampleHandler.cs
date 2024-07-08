

using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using Application.Interface;
using MediatR;

namespace Application.Handlers.ExampleHandler.Commands
{
    public class DeleteExampleHandler : IRequestHandler<DeleteExampleCommand, ExampleResponse>
    {
        private readonly IAppDbContext appDbContext;

        public DeleteExampleHandler(IAppDbContext appDbContext)
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
                await appDbContext.SaveChangesAsync(cancellationToken);
                return new ExampleResponse(true, "Xóa thành công");
            }
            catch (Exception ex)
            {
                return new ExampleResponse(false, "Lỗi");
            }
        }
    }
}
