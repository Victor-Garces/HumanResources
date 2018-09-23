using FluentValidation.AspNetCore;
using HumanResources.SqlServer;
using HumanResources.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HumanResourceContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("HumanResourcesDatabase")));
            services.AddMvc();

            AddFluentValidationConfiguration(services);
        }

        static void AddFluentValidationConfiguration(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<CompetitionValidator>();
                    configuration.RegisterValidatorsFromAssemblyContaining<LanguageValidator>();
                    configuration.RegisterValidatorsFromAssemblyContaining<TrainingValidator>();
                    configuration.RegisterValidatorsFromAssemblyContaining<PositionValidator>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
