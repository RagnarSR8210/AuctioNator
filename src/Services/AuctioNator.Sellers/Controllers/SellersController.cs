using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AuctioNator.Sellers.Data;
using AuctioNator.Sellers.Dtos;
using AuctioNator.Sellers.Models;
using AuctioNator.Sellers.SyncDataService.Http;

namespace AuctioNator.Sellers.Controllers
{
    //Kalder den [controller] istedet for at hardcode dens navn. afkobling
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellersRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHouseDataClient _houseDataClient;

        public SellersController(
            ISellersRepo repository,
            IMapper mapper,
            IHouseDataClient houseDataClient
           )
        {
            _repository = repository;
            _mapper = mapper;
            _houseDataClient = houseDataClient;

        }

        [HttpGet]
        public ActionResult<IEnumerable<SellersReadDto>> GetSellers()
        {
            Console.WriteLine("--> Getting Sellers....");

            var itemSellers = _repository.GetAllSellers();

            return Ok(_mapper.Map<IEnumerable<SellersReadDto>>(itemSellers));
        }

        [HttpGet("{id}", Name = "GetSellersById")]
        public ActionResult<SellersReadDto> GetSellersById(int id)
        {
            var itemSeller = _repository.GetSellersByID(id);
            if (itemSeller != null)
            {
                return Ok(_mapper.Map<SellersReadDto>(itemSeller));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SellersReadDto>> CreateSeller(SellersCreateDto sellerCreateDto)
        {
            var sellerModel = _mapper.Map<Seller>(sellerCreateDto);
            _repository.CreateSeller(sellerModel);
            _repository.SaveChanges();

            var sellersReadDto = _mapper.Map<SellersReadDto>(sellerModel);
            try
            {
                await _houseDataClient.SendSellersToHouse(sellersReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> could not send synchronously: {ex.Message}");
            }


            return CreatedAtRoute(nameof(GetSellersById), new { Id = sellersReadDto.Id }, sellersReadDto);
        }
    }
}

