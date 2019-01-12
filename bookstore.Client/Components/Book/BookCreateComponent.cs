using System.Threading.Tasks;
using bookstore.Shared.Api;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.Book
{
    public class BookCreateComponent : ComponentBase
    {
        [Inject]
        private BookApi BookApi { get; set; }

        protected bookstore.Shared.Model.Book Book { get; set; } = new bookstore.Shared.Model.Book();

        protected async Task CreateBook()
        {
            bool result = await Http.PutJsonAsync<bool>(BookApi.Create, Book);

            if (result)
            {
                RedirectToList();
            }
        }

        protected void RedirectToList()
        {
            UriHelper.NavigateTo("/book");
        }
    }
}
