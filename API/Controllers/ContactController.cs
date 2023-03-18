using API.Models;
using API.Repository;
using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost("new-contact")]
        public ActionResult<ResponseModel<bool>> CreateContact([FromBody] ContactModel contact)
        {
            ResponseModel<bool> response = new(_contactRepository.CreateContact(contact));

            return response;
        }

        [HttpPut("update-contact")]
        public ActionResult<ResponseModel<bool>> UpdateContact([FromBody] ContactModel contact)
        {
            ResponseModel<bool> response = new(_contactRepository.UpdateContact(contact));

            return response;
        }

        [HttpGet("contacts")]
        public ActionResult<ResponseModel<List<ContactModel>>> GetContacts()
        {
            ResponseModel<List<ContactModel>> response = new(_contactRepository.GetContacts());

            return response;
        }

        [HttpDelete("delete-contact/{id}")]

        public ActionResult<ResponseModel<bool>> DeleteContact([FromRoute] Guid id)
        {
            ResponseModel<bool> response = new(_contactRepository.DeleteContact(id));

            return response;
        }
    }
}
