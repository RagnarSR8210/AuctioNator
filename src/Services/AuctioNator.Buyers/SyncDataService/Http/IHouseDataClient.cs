using AuctioNator.Buyers.Dtos;

namespace AuctioNator.Buyers.SyncDataService.Http
{
    public interface IHouseDataClient
    {
        Task SendBuyersToHouse(BuyersReadDto item);
    }
}
