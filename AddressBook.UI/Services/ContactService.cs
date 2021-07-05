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
        public async Task<List<FirmListViewModel>> GetFirmList()
        {
            try
            {
                var response = await _httpClient.GetAsync($"firms");

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var discount = await response.Content.ReadFromJsonAsync<List<FirmListViewModel>>();

                return discount;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
