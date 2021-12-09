using AuctioNator.Sellers.Models;

namespace AuctioNator.Sellers.Data
{
    public class SellersRepo : ISellersRepo
    {
        private readonly AppDbContext _context;

        public SellersRepo(AppDbContext context)
        {
            _context = context;
        }




        public void CreateSeller(Seller sel)
        {
            if (sel == null)
            {
                throw new ArgumentNullException(nameof(sel));
            }

            _context.Sellers.Add(sel);
        }


        public IEnumerable<Seller> GetAllSellers()
        {
            return _context.Sellers.ToList();
        }

        public Seller GetSellersByID(int id)
        {
            return _context.Sellers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}


