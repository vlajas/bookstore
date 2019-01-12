using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace bookstore.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> DeleteJsonAsync<T>(this HttpClient http, string requestUri, object content = null)
        {
            return await http.SendJsonAsync<T>(HttpMethod.Delete, requestUri, content);
        }
    }
}
