using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactListWebApp.Models;
using ContactListWebApp.Services;
using ContactListWebApp.DTOs;

namespace ContactListWebApp.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IEnumerable<ContactDto>> GetFilteredContacts([FromBody] FilterDto filter)
        {
            return await _contactService.GetFilteredContacts(filter);
        }

        [HttpPost]
        public Task<int> GetNumberOfFilteredContacts([FromBody] FilterDto filter)
        {
            return _contactService.GetNumberOfFilteredContacts(filter);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateContact([FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _contactService.UpdateContact(contact);

                return StatusCode(HttpStatusCode.OK);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> AddContact([FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _contactService.AddContact(contact));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteContact(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}