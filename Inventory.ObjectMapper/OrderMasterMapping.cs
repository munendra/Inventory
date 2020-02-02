using System;
using AutoMapper;
using Inventory.Domain.Entities;

namespace Inventory.ObjectMapper
{
    public class OrderMasterMapping: Profile
    {
        public OrderMasterMapping()
        {
            CreateMap<OrderMaster, Dto.OrderMaster>().ReverseMap();
        }
    }
    
}
