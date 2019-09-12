using ContactInformation.Api.AppData;
using ContactInformation.Business;
using ContactInformation.Business.Interface;
using ContactInformation.Repository;
using ContactInformation.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace ContactInforamtion.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton(Configuration);
            services.AddLogging(configure => configure.AddSerilog());

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info { Title = "Contact Inforamtion API", Version = "v1" }); });
            
            ConfigureDependencyInjection(services);

            var srviceProvider = services.BuildServiceProvider();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Information API v1"); });
            app.UseMvc();
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IContactRepository, ContactRepository>(); //purposefully kept singleton as list is prepared there for this PoC

            services.AddScoped<IContactManager, ContactManager>();
        }
    }
}
