
using Domain.Entities;
using MediatR;

namespace Application.Features.ExampleFeatures.Queries
{
    public class GetByIdExampleQuery() : IRequest<AppExample>
    {
        //Lấy Id từ bảng Example để so sánh
        public int Id { get; set; }
    }
}
