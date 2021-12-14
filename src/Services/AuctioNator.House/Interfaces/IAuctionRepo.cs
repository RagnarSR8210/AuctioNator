using AuctioNator.House.Models;

namespace AuctioNator.House.Data
{
    public interface IAuctionRepo
    {
        bool SaveChanges();

        //auktioner
        IEnumerable<Auctions> GetAllAuctions();
        Auctions GetAuctionsById(int id);
        void CreateAuction(Auctions auc);
        void DeleteAuction(Auctions auc);
        bool ExternalAuctionExists(int externalAuctionId);
    }
}
