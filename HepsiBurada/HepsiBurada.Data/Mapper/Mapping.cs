using AutoMapper;
using HepsiBurada.Contract.Contracts.Campaign;
using HepsiBurada.Contract.Contracts.Order;
using HepsiBurada.Contract.Contracts.Product;
using HepsiBurada.Data.Models;

namespace HepsiBurada.Data.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductContract>()
                .ReverseMap();

            CreateMap<Campaign, CampaignContract>()
                .ReverseMap();

            CreateMap<Order, OrderContract>()
                .ReverseMap();
        }
    }
}