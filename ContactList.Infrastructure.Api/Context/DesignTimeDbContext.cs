using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactList.Infrastructure.Api.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<AppDbContext>
    {

        // Require Add-Migration firsr and after using Powershell Commands..

        public AppDbContext CreateDbContext(string[] args)
        {
           DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
           dbContextOptionsBuilder.UseSqlServer(Configuration.DbConfig.ConnectionString);

            return new AppDbContext(dbContextOptionsBuilder.Options);
        }

    }
}
