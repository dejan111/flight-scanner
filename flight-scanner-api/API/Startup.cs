using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ApiClient;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(new ClientCredentialsTokenRequest
            {
                Address = Configuration["Amadeus:TokenUrl"],
                ClientId = Configuration["Amadeus:ClientId"],
                ClientSecret = Configuration["Amadeus:ClientSecret"]
            });

            services.AddHttpClient<IAmadeusServerClient, AmadeusServerClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Amadeus:BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddTransient<AmadeusApiBearerTokenHandler>();

            services.AddHttpClient<IAmadeusApiClient, AmadeusApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Amadeus:BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<AmadeusApiBearerTokenHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseMvc();
        }
    }
}
