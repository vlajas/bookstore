using System.Threading.Tasks;
using bookstore.Shared.Api;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.User
{
    public class UserCreateComponent : ComponentBase
    {
        [Inject]
        private UserApi UserApi { get; set; }
        
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
