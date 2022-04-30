using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContactList.Infrastructure.Api.Context;
using ContactList.Infrastructure.Api.Configuration;
using ContactList.Infrastructure.Api.Repository;

namespace ContactList.Infrastructure.Api.Extension
{
    public static class ServiceRegistration
    {        

        public static void AddLogicService(this IServiceCollection services)
        {            
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(DbConfig.ConnectionString));            

            services.AddScoped<IContactRepository, ContactRepository>();
        }

    }

   

}
