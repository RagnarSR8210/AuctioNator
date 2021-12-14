using Auctionator.Client.DataServices;
using Microsoft.AspNetCore.Components;

namespace Auctionator.Client.Pages
{
    public class Items
    {
        [Inject]
        IAuctioNatorItems AuctionatorItems { get; set; }

        private Items[] items;

        protected override async Task OnInitializedAsync()
        {
            items = await AuctionatorItems.GetAllItems();
        }

    }
}
