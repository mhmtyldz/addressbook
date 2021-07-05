using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddressBookCreateRequest request)
        {
            return Ok(await _contactService.Create(request));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactRequest request)
        {
            return Ok(await _contactService.Update(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _contactService.Delete(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(string id)
        {
            return Ok(await _contactService.GetContact(id));
        }
    }
}
