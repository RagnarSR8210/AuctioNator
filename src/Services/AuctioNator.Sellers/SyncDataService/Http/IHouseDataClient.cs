using AuctioNator.Sellers.Dtos;

namespace AuctioNator.Sellers.SyncDataService.Http
{
    public interface IHouseDataClient
    {
        Task SendSellersToHouse(SellersReadDto item);
    }
}
