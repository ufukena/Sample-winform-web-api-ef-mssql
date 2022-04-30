using ContactList.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Infrastructure.Api.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }

    }

   

}
