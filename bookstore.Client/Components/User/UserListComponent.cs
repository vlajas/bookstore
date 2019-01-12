using System.Collections.Generic;
using System.Threading.Tasks;
using bookstore.Client.Extensions;
using bookstore.Shared.Api;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.User
{
    public class UserListComponent : ComponentBase
    {
        [Inject]
        private UserApi UserApi { get; set; }

        protected IList<bookstore.Shared.Entities.User> Users { get; private set; } = new List<bookstore.Shared.Entities.User>();

        protected override async Task OnInitAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            Users = await Http.GetJsonAsync<bookstore.Shared.Entities.User[]>(UserApi.GetAll);

            StateHasChanged();
        }

        protected async Task DeleteUser(int id)
        {
            bool result = await Http.DeleteJsonAsync<bool>(string.Format(UserApi.Delete, id));

            if (result)
            {
                await Refresh();
            }
        }
    }
}
