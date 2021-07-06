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
        [Route("/api/[controller]/numberofinfo")]
        public async Task<IActionResult> GetNumberOfSomethingInfo()
        {
            var result = await _numberOfPeopleService.GetNumberOfSomethingInfo();
            return Ok(result);
        }
    }
}
