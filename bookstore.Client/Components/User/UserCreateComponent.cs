using System.Threading.Tasks;
using bookstore.Shared.Constants;
using Microsoft.AspNetCore.Blazor;

namespace bookstore.Client.Components.User
{
    public class UserCreateComponent : ComponentBase
    {
        protected bookstore.Shared.Model.User User { get; set; } = new bookstore.Shared.Model.User();

        protected async Task CreateUser()
        {
            bool result = await Http.PutJsonAsync<bool>(UserApi.Create, User);

            if (result)
            {
                RedirectToList();
            }
        }

        protected void RedirectToList()
        {
            UriHelper.NavigateTo("/user");
        }
    }
}
