using AuctioNator.Items.Models;

namespace AuctioNator.Items.Data
{
    public interface IItemRepo
    {
        bool SaveChanges();

        IEnumerable<Item> GetAllItems();
        Item GetItemByID(int id);
        void CreateItem(Item plat);
    }
}