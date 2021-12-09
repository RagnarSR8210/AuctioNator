using AuctioNator.Items.Dtos;

namespace AuctioNator.Items.SyncDataService.Http
{
    public interface IHouseDataClient
    {
        Task SendItemToHouse(ItemReadDto item);
    }
}
