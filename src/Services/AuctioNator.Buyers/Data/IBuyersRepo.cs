using AuctioNator.Buyers.Models;

namespace AuctioNator.Buyers.Data
{
    public interface IBuyersRepo
    {
        bool SaveChanges();

        IEnumerable<Buyer> GetAllBuyers();
        Buyer GetBuyersByID(int id);
        void CreateBuyer(Buyer buy);
    }
}
