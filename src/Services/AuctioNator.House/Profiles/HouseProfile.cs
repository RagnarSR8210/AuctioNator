using AuctioNator.House.Dtos;
using AuctioNator.House.Models;
using AutoMapper;

namespace AuctioNator.House.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {

            //source --> Target

            CreateMap<Items, ItemReadDto>();
            CreateMap<ItemCreateDto, Items>();

            CreateMap<Auctions, AuctionReadDto>();
            CreateMap<AuctionCreateDto, Auctions>();
        }     
    }
}
