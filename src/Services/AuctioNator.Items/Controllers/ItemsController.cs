using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AuctioNator.Items.Data;
using AuctioNator.Items.Dtos;
using AuctioNator.Items.Models;
using AuctioNator.Items.SyncDataService.Http;
using AuctioNator.Items.AsyncDataService;

namespace AuctioNator.Items.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHouseDataClient _houseDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public ItemsController(
            IItemRepo repository, 
            IMapper mapper,
            IHouseDataClient houseDataClient,
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _houseDataClient = houseDataClient;
            _messageBusClient = messageBusClient;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetItems()
        {
            Console.WriteLine("---> Getting Items....");

            var itemItem = _repository.GetAllItems();

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(itemItem));
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<ItemReadDto> GetItemById(int id)
        {
            var itemItem = _repository.GetItemByID(id);
            if (itemItem != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(itemItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ItemReadDto>> CreateItem(ItemCreateDto itemCreateDto)
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);
            _repository.CreateItem(itemModel);
            _repository.SaveChanges();

            var itemReadDto = _mapper.Map<ItemReadDto>(itemModel);
            
            //Send sync Message
            try
            {
                await _houseDataClient.SendItemToHouse(itemReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> could not send synchronously: {ex.Message}");
            }

            //Send Async Message
            try
            {
                var itempuPlishedDto = _mapper.Map<ItemPublishedDto>(itemReadDto);
                itempuPlishedDto.Event = "Item_Published";
                _messageBusClient.PublishNewItem(itempuPlishedDto);
            }   
            catch (Exception ex)
            {
               Console.WriteLine($"---> could not send Asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetItemById), new { Id = itemReadDto.Id }, itemReadDto);
        }

    }
}

