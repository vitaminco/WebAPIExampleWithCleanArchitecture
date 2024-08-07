﻿

using Application.DTOs.SampleDTOs;
using Application.Features.SampleFeatures.Commands;
using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.SampleHandler.Commands
{
    public class UpdateSampleHandler : IRequestHandler<UpdateSampleCommand, SampleResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public UpdateSampleHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<SampleResponse> Handle(UpdateSampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var find = await appDbContext.Samples.FindAsync(request.Id);
                if (find == null)
                {
                    return new SampleResponse(false, "Ko tìm thấy");
                }
                // Tìm Example trong database dựa trên Id từ CreateSampleRequest
                var appExample = await appDbContext.Examples.FirstOrDefaultAsync(e => e.Id == request.UpdateSampleRequest.ExampleId, cancellationToken);

                if (appExample == null)
                {
                    return new SampleResponse(false, "Chưa nhập ExampleId or ExampleId Không đúng");
                }

                mapper.Map(request.UpdateSampleRequest, find);
                //Cập nhật lại dữ liệu
                find.ExampleId = appExample.Id;
                find.UpdatedAt = DateTime.UtcNow;
                //Cập nhật
                appDbContext.Samples.Update(find);
                //Lưu
                await appDbContext.SaveChangesAsync(cancellationToken);
                return new SampleResponse(true, "Cập nhật thành công");
            }
            catch (Exception ex)
            {
                return new SampleResponse(false, "Lỗi");
            }
        }
    }
}
