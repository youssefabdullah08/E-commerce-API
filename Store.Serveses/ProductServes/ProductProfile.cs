using AutoMapper;
using Store.Data.Entites;
using Store.Serveses.ProductServes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.ProductServes
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.BrandName, op => op.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.TypeName, op => op.MapFrom(src => src.Type.Name));
        }
    }
}
