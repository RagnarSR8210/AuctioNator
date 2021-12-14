namespace Auctionator.Client.Pages
{
    public class FetchDataBase
    {

        private Items[] items;

        protected override async Task OnInitializedAsync()
        {
            items = await Http.GetFromJsonAsync<Items[]>("mangophar.com/api/items");
        }
    }
}