using System;
using bookstore.Shared;
using bookstore.Shared.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace bookstore.Server.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                var context = services.GetService<BookstoreDbContext>();

                context.Seed();
            }

            return host;
        }
    }
}
