

using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using Application.Interface;
using AutoMapper;
using MediatR;

namespace Application.Handlers.ExampleHandler.Commands
{
    public class UpdateExampleHandler : IRequestHandler<UpdateExampleCommand, ExampleResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public UpdateExampleHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<ExampleResponse> Handle(UpdateExampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await appDbContext.Examples.FindAsync(request.Id);
                if (res == null)
                {
                    return new ExampleResponse(false, "Vui lòng nhập Id");
                }

                mapper.Map(request.UpdateExampleRequest, res);
                res.UpdatedAt = DateTime.Now;

                appDbContext.Examples.Update(res);
                await appDbContext.SaveChangesAsync(cancellationToken);
                return new ExampleResponse(true, "Cập nhập thành công");
            }
            catch (Exception ex)
            {
                return new ExampleResponse(false, "Lỗi");
            }
        }
    }
}
