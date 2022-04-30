using ContactList.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Api.Repository
{
    public interface IContactRepository
    {

        public Task<IEnumerable<Contact>> Get();

        public Task<Contact> Get(int id);

        public Task<Contact> Create(Contact contact);

        public Task Update(Contact contact);

        public Task Delete(int id);


    }


}
