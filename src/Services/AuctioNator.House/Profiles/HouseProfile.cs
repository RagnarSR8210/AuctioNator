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
            CreateMap<ItemPublishedDto, Items>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));


            CreateMap<Auctions, AuctionReadDto>();
            CreateMap<AuctionCreateDto, Auctions>();
            CreateMap<AuctionPublishedDto, Auctions>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));           
        }     
    }
}
