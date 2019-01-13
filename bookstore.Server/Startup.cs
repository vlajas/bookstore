using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using bookstore.Core.Data;
using bookstore.Core.Services;
using bookstore.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;

namespace bookstore.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new DefaultNamingStrategy()
                };

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddDbContext<BookstoreDbContext>(opts => opts
                .UseLazyLoadingProxies()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IAuthorizationService, AuthorizationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}
