using bookstore.Client.Services;
using bookstore.Shared.Api;
using Blazor.Toastr;
using Blazor.Toastr.Enums;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace bookstore.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<StateContainer>();
            services.AddSingleton<UserApi>();
            services.AddSingleton<BookApi>();
            services.AddStorage();
            services.AddToastr(new ToastrOptions
            {
                timeOut = 2000,
                hideDuration = 200,
                closeButton = true,
                positionClass = PositionClassType.BottomRight
            });
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
