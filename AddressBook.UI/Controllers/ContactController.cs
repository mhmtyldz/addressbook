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
            var locations =await _contactService.GetLocationList();
            ViewBag.Firms = firms;
            ViewBag.Locations = locations;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddressBookCreateRequest request)
        {
            var response =await _contactService.ContactCreate(request);
            return Json(response);
        }

        [HttpGet]
        [Route("/contact/list")]
        public async Task<IActionResult> List()
        {
            var locations = await _contactService.GetLocationList();
            ViewBag.Locations = locations;
            var result = await _contactService.GetContactList();
            return View(result);
        }
        [HttpGet]
        [Route("/contact/getdetail")]
        public async Task<IActionResult> ContactDetail(string id)
        {
            var result = await _contactService.GetContactDetail(id);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var result = await _contactService.DeleteContact(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactRequest request)
        {
            var result = await _contactService.UpdateContact(request);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> ContactInfoDetail(string id)
        {
            var result = await _contactService.ContactInfoDetail(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoRequest request)
        {
            var result = await _contactService.UpdateContactInfo(request);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var result = await _contactService.DeleteContactInfo(id);
            return Json(result);
        }
    }
}
