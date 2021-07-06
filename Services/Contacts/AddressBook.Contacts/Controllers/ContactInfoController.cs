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
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;
        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoRequest request)
        {
            return Ok(await _contactInfoService.Update(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            return Ok(await _contactInfoService.DeleteContactInfo(id));
        }
    }
}
