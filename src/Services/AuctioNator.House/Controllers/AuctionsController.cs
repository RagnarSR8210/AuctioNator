using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AuctioNator.House.Data;
using AuctioNator.House.Dtos;
using AuctioNator.House.Models;
using AuctioNator.House.Interfaces;
using AuctioNator.House.AsyncDataService;

namespace AuctioNator.House.Controllers
{
    //Kalder den [controller] istedet for at hardcode dens navn. afkobling
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public AuctionsController(
            IAuctionRepo repository,
            IMapper mapper,
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _messageBusClient = messageBusClient;

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
        public async Task<ActionResult<AuctionReadDto>> CreateAuction(AuctionCreateDto auctionCreateDto)
        {
            var itemModel = _mapper.Map<Auctions>(auctionCreateDto);
            _repository.CreateAuction(itemModel);
            _repository.SaveChanges();

            var auctionReadDto = _mapper.Map<ItemReadDto>(itemModel);

            try
            {
                Console.WriteLine("---> Auction was created");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"---> Coul not create Auction: {ex.Message}");
            }

            return Ok(_mapper.Map<IEnumerable<AuctionCreateDto>>(auctionCreateDto));


            //Send Async Message
            try
            {
                var auctionpuPlishedDto = _mapper.Map<AuctionPublishedDto>(auctionReadDto);
                auctionpuPlishedDto.Event = "Item_Published";
                _messageBusClient.PublishNewItem(auctionpuPlishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> could not send Asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetAuctionsById),
                                  new { Id = auctionReadDto.Id },
                                  auctionReadDto);
        }
    }

    
}

