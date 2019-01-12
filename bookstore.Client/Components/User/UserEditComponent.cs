using System.Threading.Tasks;
using bookstore.Shared.Constants;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace bookstore.Client.Components.User
{
    public class UserEditComponent : ComponentBase
    {
        [Inject]
        private UserApi UserApi { get; set; }

        [Parameter]
        private string UserId { get; set; }

        protected bookstore.Shared.Model.User User { get; set; } = new bookstore.Shared.Model.User();


        protected override async Task OnInitAsync()
        {
            User = await Http.GetJsonAsync<bookstore.Shared.Model.User>(string.Format(UserApi.Get, UserId));
        }

        protected async Task EditUser()
        {
            bool result = await Http.PostJsonAsync<bool>(UserApi.Update, User);

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
