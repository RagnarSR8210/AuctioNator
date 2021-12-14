using AutoMapper;
using AuctioNator.Items.Dtos;
using AuctioNator.Items.Models;

namespace AuctioNator.Items.Profiles
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            // source -> Target
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemReadDto, ItemPublishedDto>();
        }
    }
}
