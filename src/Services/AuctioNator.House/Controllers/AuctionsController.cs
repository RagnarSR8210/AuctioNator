using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AuctioNator.House.Data;
using AuctioNator.House.Dtos;
using AuctioNator.House.Models;
using AuctioNator.House.Interfaces;
using Raven.Client.Documents;
using System.Security.Cryptography.X509Certificates;

namespace AuctioNator.House.Controllers
{
    //Kalder den [controller] istedet for at hardcode dens navn. afkobling
    [Route("api/h/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;
        private DocumentStore _store;
        X509Certificate2 clientCertificate = new X509Certificate2("C:\\Users\\Ragna\\AppData\\Roaming\\Microsoft\\SystemCertificates\\My\\Certificates\\E349A40EDE36501F2DD483E54D916C6B18AE5CE0");

        public AuctionsController(
            IAuctionRepo repository,
            IMapper mapper,
            IMessageBusClient messageBusClient)
        {

            _repository = repository;
            _mapper = mapper;

            _store = new DocumentStore
            {
                Urls = new[] { "https://a.free.auctionator.ravendb.cloud/studio/index.html#databases/documents?&database=AuctioNatorHouse" },
                Database = "AuctioNatorHouse",
                Certificate = clientCertificate
            };

            _store.Initialize();
            //_messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuctionReadDto>> GetAuctions()
        {
            Console.WriteLine("---> Getting Auctions....");

            var itemAuction = _repository.GetAllAuctions();

            return Ok(_mapper.Map<IEnumerable<AuctionReadDto>>(itemAuction));
        }

        

        [HttpGet("{id}", Name = "GetAuctionById")]
        public ActionResult<AuctionReadDto> GetAuctionsById(int id)
        {
            var itemAuction = _repository.GetAuctionsById(id);
            if (itemAuction != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(itemAuction));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<AuctionReadDto> CreateAuction(AuctionCreateDto auctionCreateDto)
        {
            var itemModel = _mapper.Map<Auctions>(auctionCreateDto);
            _repository.CreateAuction(itemModel);
            _repository.SaveChanges();

            var auctionReadDto = _mapper.Map<AuctionReadDto>(itemModel);

            try
            {
                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"---> Could not create Auction: {ex.Message}");
            }

            return Ok(_mapper.Map<IEnumerable<AuctionCreateDto>>(auctionCreateDto));    
        }



        [HttpPost]
        public async Task<IEnumerable<AuctionReadDto>> RavenPostAuction(AuctionCreateDto auction)
        {
            using (var session = _store.OpenAsyncSession())
            {
                var newAuction = new AuctionCreateDto
                {
                    Name = auction.Name,
                    Price = auction.Price,
                    SellerId = auction.SellerId,
                    ExpirationDate = auction.ExpirationDate

                };

                await session.StoreAsync(auction);
                await session.SaveChangesAsync();

                return await session.Query<AuctionReadDto>().Where(s => s.Id != null).ToListAsync();
            }

        
}

 }

    
}

