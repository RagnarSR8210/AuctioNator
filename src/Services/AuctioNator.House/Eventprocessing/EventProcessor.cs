using AuctioNator.House.Data;
using AuctioNator.House.Dtos;
using AuctioNator.House.Models;
using AutoMapper;
using System.Text.Json;

namespace AuctioNator.House.Eventprocessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopefactory;
        private readonly IMapper _mapper;


        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopefactory = scopeFactory;
            _mapper = mapper;
        }



        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.ItemPublished:
                    //TO DO
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("---> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Item_Published":
                    Console.WriteLine("---> Item Published Event Detected");
                    return EventType.ItemPublished;

                default:
                    Console.WriteLine("---> Could not determine the event type");
                    return EventType.Undetermind;
            }
        }

        private void addItem(string itemPublishedMessage)
        {
            using (var scope = _scopefactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IHouseRepo>();

                var itemPublishedDto = JsonSerializer.Deserialize<ItemPublishedDto>(itemPublishedMessage);

                try
                {
                    var item = _mapper.Map<Items>(itemPublishedDto);
                    if (!repo.ExternalItemExists(item.ExternalID))
                    {
                        repo.CreateItem(item);
                        repo.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("---> Platform already exists...");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"---> Could not add Platform to DB {ex.Message}");
                }

            }

        }
    }

    enum EventType
    {
        ItemPublished,
        Undetermind
    }
}