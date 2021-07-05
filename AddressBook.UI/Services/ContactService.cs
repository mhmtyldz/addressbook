using AddressBook.Shared.Models.Request;
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
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ContactCreate(AddressBookCreateRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("contacts", request);
            return await response.Content.ReadFromJsonAsync<bool>(); ;
        }

        public async Task<List<FirmListViewModel>> GetFirmList()
        {

            var response = await _httpClient.GetAsync($"firms");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var firms = await response.Content.ReadFromJsonAsync<List<FirmListViewModel>>();

            return firms;
        }

        public async Task<List<LocationListViewModel>> GetLocationList()
        {
            var response = await _httpClient.GetAsync($"locations");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var locations = await response.Content.ReadFromJsonAsync<List<LocationListViewModel>>();
            return locations;
        }
    }
}
