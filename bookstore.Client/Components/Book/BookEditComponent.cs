using System.Threading.Tasks;
using bookstore.Shared.Api;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.Book
{
    public class BookEditComponent : ComponentBase
    {
        [Inject]
        private BookApi BookApi { get; set; }

        [Parameter]
        private string BookId { get; set; }

        protected bookstore.Shared.Model.Book Book { get; set; } = new bookstore.Shared.Model.Book();


        protected override async Task OnInitAsync()
        {
            Book = await Http.GetJsonAsync<bookstore.Shared.Model.Book>(string.Format(BookApi.Get, BookId));
        }

        protected async Task EditBook()
        {
            bool result = await Http.PostJsonAsync<bool>(BookApi.Update, Book);

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
