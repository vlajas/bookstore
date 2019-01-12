using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace bookstore.Client.Components
{
    public abstract class ComponentBase : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }
    }
}
