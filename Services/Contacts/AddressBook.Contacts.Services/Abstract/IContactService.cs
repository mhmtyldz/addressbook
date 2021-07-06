using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Abstract
{
    public interface IContactService
    {
        Task<AddressBookCreateViewModel> Create(AddressBookCreateRequest request);
        Task<bool> Update(UpdateContactRequest request);
        Task<bool> Delete(string id);
        Task<List<ContactListViewModel>> GetAll();
        Task<ContactDetailViewModel> GetContact(string id);
    }
}
