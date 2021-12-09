using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AuctioNator.Buyers.Data;
using AuctioNator.Buyers.Dtos;
using AuctioNator.Buyers.Models;
using AuctioNator.Buyers.SyncDataService.Http;

namespace AuctioNator.Buyers.Controllers
{
    //Kalder den [controller] istedet for at hardcode dens navn. afkobling
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IBuyersRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHouseDataClient _houseDataClient;

        public BuyersController(
            IBuyersRepo repository,
            IMapper mapper,
            IHouseDataClient houseDataClient
           )
        {
            _repository = repository;
            _mapper = mapper;
            _houseDataClient = houseDataClient;

        }

        [HttpGet]
        public ActionResult<IEnumerable<BuyersReadDto>> GetBuyers()
        {
            Console.WriteLine("--> Getting Buyers....");

            var itemBuyers = _repository.GetAllBuyers();

            return Ok(_mapper.Map<IEnumerable<BuyersReadDto>>(itemBuyers));
        }

        [HttpGet("{id}", Name = "GetBuyersById")]
        public ActionResult<BuyersReadDto> GetBuyersById(int id)
        {
            var itemBuyer = _repository.GetBuyersByID(id);
            if (itemBuyer != null)
            {
                return Ok(_mapper.Map<BuyersReadDto>(itemBuyer));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BuyersReadDto>> CreateBuyer(BuyersCreateDto buyersCreateDto)
        {
            var buyerModel = _mapper.Map<Buyer>(buyersCreateDto);
            _repository.CreateBuyer(buyerModel);
            _repository.SaveChanges();

            var buyersReadDto = _mapper.Map<BuyersReadDto>(buyerModel);
            try
            {
                await _houseDataClient.SendBuyersToHouse(buyersReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> could not send synchronously: {ex.Message}");
            }


            return CreatedAtRoute(nameof(GetBuyersById), new { Id = buyersReadDto.Id }, buyersReadDto);
        }
    }
}

