using AutoMapper;
using AuctioNator.Items.Dtos;
using AuctioNator.Items.Models;

namespace AuctioNator.Items.Profiles
{
    public class ItemsProfile : Profile
    {

        /*skaber en profil for automapping, det binder source og target sammen,
        de her nedenunder er nemme fordi de hedder PRÆCIS det samme,
        men det kan være mere kringlet */

        public ItemsProfile()
        {
            // source -> Target
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemReadDto, ItemPublishedDto>();
        }
    }
}
