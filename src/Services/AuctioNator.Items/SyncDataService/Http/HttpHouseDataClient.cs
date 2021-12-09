using System.Text;
using System.Text.Json;
using AuctioNator.Items.Dtos;

namespace AuctioNator.Items.SyncDataService.Http
{
    public class HttpHouseDataClient : IHouseDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpHouseDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendItemToHouse(ItemReadDto item)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(item),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["AuctioNator.House"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("---> Sync POST to House was OK!");
            }
            else
            {
                Console.WriteLine("---> Sync POST to HouseService was  NOT OK!");
            }

        }
    }
}
