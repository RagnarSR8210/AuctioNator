using Auctionator.Client.Data;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
namespace Auctionator.Client.Pages
{
    public class FetchDataBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        private ItemsDto[] items;


        protected async Task OnInitializedAsync()
        {
            items = await Http.GetFromJsonAsync<ItemsDto[]>("http://mangophar.com/api/items");
        }
    }
}