

using Application.DTOs.SampleDTOs;
using Application.Features.SampleFeatures.Commands;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.SampleHandler.Commands
{
    public class DeleteSampleHandler : IRequestHandler<DeleteSampleCommand, SampleResponse>
    {
        private readonly AppDbContext appDbContext;

        public DeleteSampleHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<SampleResponse> Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var find = await appDbContext.Samples.FindAsync(request.Id);
                if (find is null)
                {
                    return new SampleResponse(false, "Không tìm thấy!, Lỗi");
                }

                appDbContext.Samples.Remove(find);
                await appDbContext.SaveChangesAsync();
                return new SampleResponse(true, "Xóa thành công");
            }
            catch (Exception ex)
            {
                return new SampleResponse(false, "Lỗi");
            }
        }
    }
}
