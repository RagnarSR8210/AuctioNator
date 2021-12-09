using System.Text;
using System.Text.Json;
using AuctioNator.Sellers.Dtos;
using AuctioNator.Sellers.SyncDataService.Http;

namespace AuctioNator.Sellers.SyncDataService.Http
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

        public async Task SendSellersToHouse(SellersReadDto seller)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(seller),
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
