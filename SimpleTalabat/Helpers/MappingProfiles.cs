using AutoMapper;
using SimpleTalabat.DTOS;
using Talabat.Core.Entities;

namespace SimpleTalabat.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(S => S.Brand.Name))
                .ForMember(d => d.Category,O => O.MapFrom(S => S.Category.Name));

        }
    }
}
