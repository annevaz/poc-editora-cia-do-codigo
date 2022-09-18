using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PIOL.Api.Data;
using PIOL.Data.Context;

namespace PIOL.Api.Configuration
{
    public class AuthDatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
            }
        }
    }
}
