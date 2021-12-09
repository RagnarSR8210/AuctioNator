using AutoMapper;
using AuctioNator.Buyers.Dtos;
using AuctioNator.Buyers.Models;

namespace AuctioNator.Buyers.Profiles
{
    public class BuyersProfile : Profile
    {
        public BuyersProfile()
        {
            CreateMap<Buyer, BuyersReadDto>();
            CreateMap<BuyersCreateDto, Buyer>();
        }
    }
}
