using AddressBook.Shared.ViewModel;
using AddressBook.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AddressBook.UI.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<NumberOfSomethingViewModel> GetNumberOfSomethingInfo()
        {
            var response = await _httpClient.GetAsync($"reports/numberofinfo");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var contactDetail = await response.Content.ReadFromJsonAsync<NumberOfSomethingViewModel>();

            return contactDetail;
        }
    }
}
