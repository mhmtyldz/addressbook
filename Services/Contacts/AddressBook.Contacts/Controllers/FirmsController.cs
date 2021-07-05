using AddressBook.Contacts.Services.Abstract;
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
    public class FirmsController : ControllerBase
    {
        private readonly IFirmService _firmService;
        public FirmsController(IFirmService firmService)
        {
            _firmService = firmService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFirmList()
        {
            return Ok(await _firmService.GetFirmList());
        }
    }
}
