using AuctioNator.House.Models;

namespace AuctioNator.House.Data
{
    public interface IAuctionRepo
    {
        bool SaveChanges();

        IEnumerable<Auctions> GetAllAuctions();
        Auctions GetAuctionsById(int id);
        void CreateAuction(Auctions auc);
        void DeleteAuction(Auctions auc);
    }
}
