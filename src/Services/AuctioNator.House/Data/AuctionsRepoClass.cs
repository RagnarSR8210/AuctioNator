using AuctioNator.House.Models;

namespace AuctioNator.House.Data
{
    public class AuctionsRepoClass : IAuctionRepo
    {
        private readonly AppDbContext _context;

        public AuctionsRepoClass(AppDbContext context)
        {
            _context = context;
        }
        //Rettes til at være mongoDB men er på nuværende tidspunkt inMem for at teste
        public void CreateAuction(Auctions auc)
        {
            if (auc == null)
            {
                throw new ArgumentNullException(nameof(auc));
            }

            _context.Auctions.Add(auc);
        }

        public void DeleteAuction(Auctions auc)
        {
            if (auc != null)
            {
                _context.Auctions.Remove(auc);
            }
        }

        public bool ExternalAuctionExists(int externalItemId)
        {
            return _context.Items.Any(p => p.ExternalId == externalItemId);
        }

        public IEnumerable<Auctions> GetAllAuctions()
        {
            return _context.Auctions.ToList();
        }

        public Auctions GetAuctionsById(int id)
        {
            return _context.Auctions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
