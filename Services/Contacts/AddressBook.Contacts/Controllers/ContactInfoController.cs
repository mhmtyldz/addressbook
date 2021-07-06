using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Messages;
using AddressBook.Shared.Models.Request;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public ContactInfoController(IContactInfoService contactInfoService, ISendEndpointProvider sendEndpointProvider)
        {
            _contactInfoService = contactInfoService;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoRequest request)
        {
            var result = await _contactInfoService.Update(request);
            if (result)
            {
                var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:people-at-location"));
                var numberOfAtThatLocationCommand = new NumberOfPeopleAtThatLocationCommand();
                numberOfAtThatLocationCommand.ContactId = request.ContactId;
                numberOfAtThatLocationCommand.LocationId = request.LocationId;
                numberOfAtThatLocationCommand.PhoneNumber = request.PhoneNumber;
                numberOfAtThatLocationCommand.ProcessType = ProcessType.ContactInfoUpdated;
                await sendEndPoint.Send(numberOfAtThatLocationCommand);
                result = true;
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            bool response = false;
            var result = await _contactInfoService.DeleteContactInfo(id);
            if (result != null)
            {
                var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:people-at-location"));
                var numberOfAtThatLocationCommand = new NumberOfPeopleAtThatLocationCommand();
                numberOfAtThatLocationCommand.ContactId = result.ContactId;
                numberOfAtThatLocationCommand.LocationId = result.LocationId;
                numberOfAtThatLocationCommand.ProcessType = ProcessType.ContactInfoDeleted;
                await sendEndPoint.Send(numberOfAtThatLocationCommand);
                response = true;
            }
            return Ok(response);
        }
    }
}
