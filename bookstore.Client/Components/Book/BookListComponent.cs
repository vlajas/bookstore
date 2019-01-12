using System.Collections.Generic;
using System.Threading.Tasks;
using bookstore.Client.Extensions;
using bookstore.Shared.Api;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.Book
{
    public class BookListComponent : ComponentBase
    {
        [Inject]
        private BookApi BookApi { get; set; }

        protected IList<bookstore.Shared.Entities.Book> Books { get; private set; } = new List<bookstore.Shared.Entities.Book>();

        protected override async Task OnInitAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            Books = await Http.GetJsonAsync<bookstore.Shared.Entities.Book[]>(BookApi.GetAll);

            StateHasChanged();
        }

        protected async Task DeleteBook(int id)
        {
            bool result = await Http.DeleteJsonAsync<bool>(string.Format(BookApi.Delete, id));

            if (result)
            {
                await Refresh();
            }
        }
    }
}
