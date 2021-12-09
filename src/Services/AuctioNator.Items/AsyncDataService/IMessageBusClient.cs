using AuctioNator.Items.Dtos;

namespace AuctioNator.Items.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewItem(ItemPublishedDto itemPublishedDto);
    }
}
