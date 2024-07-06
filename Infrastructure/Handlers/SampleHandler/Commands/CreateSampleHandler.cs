

using Application.DTOs.SampleDTOs;
using Application.Features.SampleFeatures.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.SampleHandler.Commands
{
    public class CreateSampleHandler : IRequestHandler<CreateSampleCommand, SampleResponse>
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreateSampleHandler(AppDbContext appDbContext, IMapper mapper)
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
                await appDbContext.AddAsync(res);
                await appDbContext.SaveChangesAsync();

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
