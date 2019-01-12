using System.Collections.Generic;
using System.Threading.Tasks;
using bookstore.Client.Extensions;
using bookstore.Shared.Constants;
using Microsoft.AspNetCore.Blazor;

namespace bookstore.Client.Components.User
{
    public class UserListComponent : ComponentBase
    {
        protected IList<bookstore.Shared.Model.User> Users { get; private set; } = new List<bookstore.Shared.Model.User>();

        protected override async Task OnInitAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            Users = await Http.GetJsonAsync<bookstore.Shared.Model.User[]>(UserApi.GetAll);

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
