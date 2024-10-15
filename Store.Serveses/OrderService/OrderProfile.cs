using AutoMapper;
using Store.Data.Entites.OrderEntityies;
using Store.Serveses.OrderService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.OrderService
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShepingAdress, ShepingAdressDTO>().ReverseMap();
            CreateMap<Order, OrderDetailsDTO>()
                .ForMember(dest => dest.dlivaryMethodName, options => options.MapFrom(src => src.dlivaryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, options => options.MapFrom(src => src.dlivaryMethod.Price));

        }
    }
}
