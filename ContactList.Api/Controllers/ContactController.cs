using ContactList.Domain.Model;
using ContactList.Infrastructure.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace ContactList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("Get")]
        [HttpGet]        
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactRepository.Get();
        }

        
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            return await _contactRepository.Get(id);
        }

        [Route("Insert")]
        [HttpPost]
        public async Task<ActionResult<Contact>> Insert([FromBody] Contact contact)
        {
            var newContact = await _contactRepository.Create(contact);

            return CreatedAtAction(nameof(Get), new { id = newContact.Id }, newContact);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Contact contact)
        {            
            await _contactRepository.Update(contact);

            return NoContent();
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var contactToDelete = await _contactRepository.Get(id);

            if (contactToDelete == null){
                return NotFound();
            }

            await _contactRepository.Delete(contactToDelete.Id);
            return NoContent();
        }


    }
}
