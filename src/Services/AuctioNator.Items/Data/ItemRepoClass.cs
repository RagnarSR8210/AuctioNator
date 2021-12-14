
using AuctioNator.Items.Models;


namespace AuctioNator.Items.Data
{
    //Data jeg laver mine platforme ud fra. Implementerer interface "IPlatformRepo"
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _context;

        public ItemRepo(AppDbContext context)
        {
            _context = context;
        }




        public void CreateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);
        }


        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }


        public Item GetItemByID(int id)
        {
            return _context.Items.FirstOrDefault(p => p.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteItemByID(int id)
        {
            _context.Remove(id);
        }
    }
}