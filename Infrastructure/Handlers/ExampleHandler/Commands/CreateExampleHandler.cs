

using Application.DTOs.ExampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.ExampleHandler.Commands
{
    public class CreateExampleHandler : IRequestHandler<CreateExampleCommand, ExampleResponse>
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreateExampleHandler(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<ExampleResponse> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataAdd = mapper.Map<AppExample>(request.CreateExampleRequest);
                if (dataAdd is null)
                {
                    return new ExampleResponse(true, "Thêm không thành công, vui lòng thêm dử liệu");
                }
                dataAdd.CreatedAt = DateTime.Now;
                // tạo & lưu
                await appDbContext.AddAsync(dataAdd);
                await appDbContext.SaveChangesAsync();
                /*  //thêm
                  appDbContext.Examples.Add(mapper.Map<AppExample>(request.CreateExampleRequest));

                  await appDbContext.SaveChangesAsync(cancellationToken);*/
                return new ExampleResponse(true, "Thêm thành công");
            }
            catch (Exception ex)
            {
                return new ExampleResponse(false, "Lỗi");
            }
        }
    }
}
