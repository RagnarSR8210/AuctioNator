using AutoMapper;
using AuctioNator.Sellers.Dtos;
using AuctioNator.Sellers.Models;

namespace AuctioNator.Sellers.Profiles
{
    public class SellersProfile : Profile
    {
        public SellersProfile()
        {
            CreateMap<Seller, SellersReadDto>();
            CreateMap<SellersCreateDto, Seller>();
        }
    }
}
