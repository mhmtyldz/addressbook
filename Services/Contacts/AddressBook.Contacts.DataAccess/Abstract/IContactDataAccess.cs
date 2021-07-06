using AddressBook.Contacts.Entities;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.Repository;
using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Abstract
{
    public interface IContactDataAccess : IRepository<Contact>
    {
        Task<AddressBookCreateViewModel> CreateContact(AddressBookCreateRequest request);
        Task<bool> DeleteContactAndContactInfo(string id);
        Task<List<ContactListViewModel>> GetAllWithContactInfo();
    }
}
