using AuctioNator.House.Dtos;

namespace AuctioNator.House.Interfaces
{
    public interface IMessageBusClient
    {
        void PublishNewItem(AuctionPublishedDto actionPublishedDto);
    }
}
