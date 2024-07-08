
using Application.DTOs.ExampleDTOs;
using Application.DTOs.SampleDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Mapper Example
            CreateMap<CreateExampleRequest, AppExample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // bỏ qua về để cho cột đó null
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<UpdateExampleRequest, AppExample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateExampleRequest, AppExample>());
            //Mapper Sample
            CreateMap<CreateSampleRequest, AppSample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<UpdateSampleRequest, AppSample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateSampleRequest, AppSample>());
        }
    }
}
