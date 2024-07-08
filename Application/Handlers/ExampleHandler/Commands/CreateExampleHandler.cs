

using Application.DTOs.ExampleDTOs;
using Application.DTOs.SampleDTOs;
using Application.Features.ExampleFeatures.Commands;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.ExampleHandler.Commands
{
    public class CreateExampleHandler : IRequestHandler<CreateExampleCommand, ExampleResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreateExampleHandler(IAppDbContext appDbContext, IMapper mapper)
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
                    return new ExampleResponse(false, "Chưa nhập dữ liệu");
                }

                dataAdd.CreatedAt = DateTime.Now;

                // tạo & lưu
                await appDbContext.Examples.AddAsync(dataAdd);
                await appDbContext.SaveChangesAsync(cancellationToken);
                /*  //thêm
                  appDbContext.Examples.Add(mapper.Map<AppExample>(request.CreateExampleRequest));

                  await appDbContext.SaveChangesAsync(cancellationToken);*/
                return new ExampleResponse(true, "Thêm thành công");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return new ExampleResponse(false, "Lỗi");
            }
        }

    }
}

