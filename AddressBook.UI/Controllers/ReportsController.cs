using AddressBook.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IReportService _reportService;

        public ReportsController(IContactService contactService, IReportService reportService)
        {
            _contactService = contactService;
            _reportService = reportService;

        }

        public async Task<IActionResult> Statistic()
        {
            var locations = await _contactService.GetLocationList();
            var reports = await _reportService.GetNumberOfSomethingInfo();
            if (reports != null && locations != null)
            {
                reports.NumberOfPeople
                    .ForEach(x => x.LocationName = locations.FirstOrDefault(y => y.Id == x.LocationId).Name);

                reports.NumberOfPhoneNumber
                    .ForEach(x => x.LocationName = locations.FirstOrDefault(y => y.Id == x.LocationId).Name);
            }
            return View(reports);
        }
    }
}
