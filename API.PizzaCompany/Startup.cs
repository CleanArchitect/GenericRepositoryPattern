using Domain.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.PizzaCompany
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureModules(services);
            ConfigureApiServices(services);
            ConfigureAspNetCoreServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(builder => builder.MapHub<BestellingenHub>("/bestellingenHub"));
            app.UseMvc();
        }

        private void ConfigureModules(IServiceCollection services)
        {
            Data.PizzaCompany.Startup.ConfigureServices(services, configuration);
            Domain.PizzaCompany.Startup.ConfigureServices(services);
        }

        private static void ConfigureApiServices(IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
        }

        private static void ConfigureAspNetCoreServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSignalR();
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Domain.PizzaCompany.Pizza>());
        }
    }
}
