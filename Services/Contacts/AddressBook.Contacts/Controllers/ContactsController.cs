using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Messages;
using AddressBook.Shared.Models.Request;
using MassTransit;
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
        private readonly IContactInfoService _contactInfoService;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public ContactsController(IContactService contactService, IContactInfoService contactInfoService, ISendEndpointProvider sendEndpointProvider)
        {
            _contactService = contactService;
            _contactInfoService = contactInfoService;
            _sendEndpointProvider = sendEndpointProvider;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddressBookCreateRequest request)
        {
            var response = false;
            var result = await _contactService.Create(request);
            if (!string.IsNullOrEmpty(result.ContactId))
            {
                //rabbitmq publish process
                var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:people-at-location"));
                var numberOfAtThatLocationCommand = new NumberOfPeopleAtThatLocationCommand();
                numberOfAtThatLocationCommand.ContactId = result.ContactId;
                numberOfAtThatLocationCommand.LocationId = result.LocationId;
                numberOfAtThatLocationCommand.PhoneNumber = request.PhoneNumber;
                numberOfAtThatLocationCommand.ProcessType = ProcessType.ContactCreated;
                await sendEndPoint.Send(numberOfAtThatLocationCommand);
                response = true;
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactRequest request)
        {
            return Ok(await _contactService.Update(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _contactService.Delete(id);
            if (result)
            {
                var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:people-at-location"));
                var numberOfAtThatLocationCommand = new NumberOfPeopleAtThatLocationCommand();
                numberOfAtThatLocationCommand.ContactId = id;
                numberOfAtThatLocationCommand.ProcessType = ProcessType.ContactDeleted;
                await sendEndPoint.Send(numberOfAtThatLocationCommand);
                result = true;
            }
            return Ok(result);
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
        [Route("contactinfo/{id}")]
        public async Task<IActionResult> GetContactInfo(string id)
        {
            return Ok(await _contactInfoService.GetContactInfo(id));
        }
    }
}
