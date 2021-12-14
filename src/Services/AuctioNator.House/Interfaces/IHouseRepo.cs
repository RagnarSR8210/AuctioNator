using AuctioNator.House.Models;

namespace AuctioNator.House.Data
{
    public interface IHouseRepo
    {
        bool SaveChanges();


        //Items
        IEnumerable<Items> GetAllItems();
        void CreateItem(Items item);
        bool ItemExists(int itemId);
        bool ExternalItemExists(int externalItemId);


        //huset?

    }
}
