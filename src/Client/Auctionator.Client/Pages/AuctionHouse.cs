using Microsoft.AspNetCore.Components;
using Auctionator.Client.Data;

namespace Auctionator.Client.Pages
{
    
    
        public partial class FetchData
        {
            [Inject]
            private HttpClient Http { get; set; }

            private Items[] items;

            protected override async Task OnInitializedAsync()
            {
                items = await Http.GetFromJsonAsync<Items[]>("mangophar.com/api/items");
            }
        }
    
}
