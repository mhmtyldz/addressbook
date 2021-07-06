using AddressBook.Reports.Services.Interfaces;
using AddressBook.Shared.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly INumberOfPeopleService _numberOfPeopleService;

        public ReportsController(INumberOfPeopleService numberOfPeopleService)
        {
            _numberOfPeopleService = numberOfPeopleService;
        }
        [HttpPost]
        [Route("/api/[controller]/update-number-of-people")]
        public async Task<IActionResult> Update(NumberOfPeopleAtThatLocationCommand request)
        {
            //var result = _numberOfPeopleService.
            return Ok();
        }
    }
}
