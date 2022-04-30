using ContactList.Domain.Model;
using ContactList.Infrastructure.Api.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ContactList.Infrastructure.Api.Repository
{

    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Contact> Create(Contact contact)
        {
            _appDbContext.Add(contact);
            await _appDbContext.SaveChangesAsync();

            return contact;
        }

        public async Task Delete(int id)
        {
            var contactToDelete = await _appDbContext.Contact.FindAsync(id);

            if (contactToDelete != null)
            {
                _appDbContext.Contact.Remove(contactToDelete);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> Get()
        {
            return await _appDbContext.Contact.ToListAsync();
        }

        public async Task<Contact> Get(int id)
        {
            return await _appDbContext.Contact.FindAsync(id);
        }

        public async Task Update(Contact contact)
        {
            _appDbContext.Entry(contact).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

    }

}
