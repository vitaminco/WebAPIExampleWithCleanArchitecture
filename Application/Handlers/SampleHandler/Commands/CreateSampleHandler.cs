

using Application.DTOs.SampleDTOs;
using Application.Features.SampleFeatures.Commands;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.SampleHandler.Commands
{
    public class CreateSampleHandler : IRequestHandler<CreateSampleCommand, SampleResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreateSampleHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<SampleResponse> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map dữ liệu từ CreateSampleRequest vào AppSample
                var res = mapper.Map<AppSample>(request.CreateSampleRequest);

                // Tìm Example trong database dựa trên Id từ CreateSampleRequest
                var appExample = await appDbContext.Examples.FirstOrDefaultAsync(e => e.Id == request.CreateSampleRequest.ExampleId, cancellationToken);

                if (appExample == null)
                {
                    return new SampleResponse(false, "Chưa nhập ExampleId or ExampleId Không đúng");
                }

                if (res is null)
                {
                    return new SampleResponse(false, "Chưa nhập dữ liệu");
                }

                res.CreatedAt = DateTime.Now;
                res.ExampleId = appExample.Id;

                // Thêm và lưu dữ liệu
                await appDbContext.Samples.AddAsync(res);
                await appDbContext.SaveChangesAsync(cancellationToken);

                return new SampleResponse(true, "Thêm dữ liệu thành công");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return new SampleResponse(false, "Lỗi");
            }
        }
    }
}
