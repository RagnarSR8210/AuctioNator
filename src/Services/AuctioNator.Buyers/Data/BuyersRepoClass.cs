using AuctioNator.Buyers.Models;

namespace AuctioNator.Buyers.Data
{
    public class BuyersRepo : IBuyersRepo
    {
        private readonly AppDbContext _context;

        public BuyersRepo(AppDbContext context)
        {
            _context = context;
        }



       
        public void CreateBuyer(Buyer buy)
        {
            if (buy== null)
            {
                throw new ArgumentNullException(nameof(buy));
            }

            _context.Buyers.Add(buy);
        }


        public IEnumerable<Buyer> GetAllBuyers()
        {
            return _context.Buyers.ToList();
        }

        public Buyer GetBuyersByID(int id)
        {
            return _context.Buyers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}


