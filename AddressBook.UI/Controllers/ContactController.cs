using AddressBook.Shared.Models.Request;
using AddressBook.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        [Route("/contact/add")]
        public async Task<IActionResult> Add()
        {
            var firms =await _contactService.GetFirmList();
            ViewBag.Firms = firms;
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddressBookCreateRequest request)
        {
            return View();
        }
    }
}
