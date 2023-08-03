using API.Models;
using AutoMapper;
using Core.Entities;
using PlayaEstacionamientoAPI.Models;

namespace API.Dependencies
{
    public static class AutoMapperDependencyInjection
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mcg =>
            {
                mcg.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Estado, EstadoModel>();
            CreateMap<Inspection, InspectionModel>();
            CreateMap<InspectionType, InspectionTypeModel>();
        }
    }
}
