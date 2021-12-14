using Auctionator.Client.Data;

namespace Auctionator.Client.DataServices
{
    public interface IAuctioNatorItems
    {
        Task<Items[]> GetAllItems();
    }
}
