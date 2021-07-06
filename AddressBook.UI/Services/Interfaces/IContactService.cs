using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<FirmListViewModel>> GetFirmList();
        Task<List<LocationListViewModel>> GetLocationList();
        Task<List<ContactListViewModel>> GetContactList();
        Task<ContactDetailViewModel> GetContactDetail(string id);
        Task<ContactInfoDetailViewModel> ContactInfoDetail(string id);
        Task<bool> DeleteContact(string id);
        Task<bool> DeleteContactInfo(int id);
        Task<bool> ContactCreate(AddressBookCreateRequest request);
        Task<bool> UpdateContact(UpdateContactRequest request);
        Task<bool> UpdateContactInfo(UpdateContactInfoRequest request);
    }
}
