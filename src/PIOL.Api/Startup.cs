using AutoMapper;
using PIOL.Api.Configuration;
using PIOL.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PIOL.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = $"Data Source=tcp:pioldbserver.database.windows.net,1433;Initial Catalog=PIOL.Api_db;User Id=;Password=";

            services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("PIOL.Api"));
            });

            services.AddIdentityConfig(Configuration, connectionString);

            services.AddAutoMapper(typeof(Startup));

            services.AddApiConfig();

            services.AddSwaggerConfig();

            services.ResolveDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);

            DatabaseManagementService.MigrationInitialisation(app);
            AuthDatabaseManagementService.MigrationInitialisation(app);

            app.UseSwaggerConfig(provider);
        }
    }
}
