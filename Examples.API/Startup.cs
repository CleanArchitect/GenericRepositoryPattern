using Examples.Data;
using Examples.Data.MongoDb;
using Examples.Domain.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Examples.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();

            // Registreer de datacontext
            //services.AddDbContext<EfDataContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ExamplesDatabase"))
            //);
            //services.AddTransient<IDataContext>(provider =>
            //{
            //    return provider.GetService<EfDataContext>();
            //});
            services.AddTransient<IDataContext, MongoDbContext>();
            services.Configure<MongoDbContext.MongoDbOptions>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });

            // Registreer de authenticated user
            services.AddScoped(provider =>
            {
                return provider.GetService<IHttpContextAccessor>().HttpContext.User.Identity;
            });

            // Registreer de open generic repositories
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IReadWriteRepository<>), typeof(ReadWriteRepository<>));

            // Registreer alle usecases
            foreach (var useCaseType in Assembly.GetAssembly(typeof(IUseCase<,>)).GetTypes().Where(type => type.IsClass && type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IUseCase<,>))))
            {
                foreach (var useCaseInterface in useCaseType.GetInterfaces())
                {
                    services.AddTransient(useCaseInterface, useCaseType);
                }
            }
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
            app.UseMvc();
        }
    }
}
