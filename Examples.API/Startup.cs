using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Presentation.API
{
    public class Startup
    {
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("MongoDb");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Data.Startup.ConfigureServices(services, connectionString);
            Domain.Startup.ConfigureServices(services);

            ConfigurePresentationServices(services);
            ConfigureAspNetCoreServices(services);
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

            // Make sure the CORS middleware is ahead of SignalR.
            app.UseCors("CorsPolicy");
            app.UseSignalR(builder => builder.MapHub<ExampleHub>("/exampleHub"));
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void ConfigurePresentationServices(IServiceCollection services)
        {
            services.AddTransient<Domain.IAuthService, AuthService>();
        }

        private static void ConfigureAspNetCoreServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddHttpContextAccessor();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
