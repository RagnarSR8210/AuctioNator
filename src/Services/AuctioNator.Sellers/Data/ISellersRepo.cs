using AuctioNator.Sellers.Models;

namespace AuctioNator.Sellers.Data
{
    public interface ISellersRepo
    {
        bool SaveChanges();

        IEnumerable<Seller> GetAllSellers();
        Seller GetSellersByID(int id);
        void CreateSeller(Seller sel);
    }
}
