using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDto>()
                .ForMember(dest=>dest.ProductBrand,src=>src.MapFrom(src=>src.ProductBrand.Name))
                .ForMember(dest=>dest.ProductType,src=>src.MapFrom(src=>src.ProductType.Name))
                .ForMember(dest=>dest.PictureUrl,src=>src.MapFrom<ProductUrlResolver>());
        }
    }
}