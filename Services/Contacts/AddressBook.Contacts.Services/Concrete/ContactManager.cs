using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDataAccess _contactDataAccess;
        public ContactManager(IContactDataAccess contactDataAccess)
        {
            _contactDataAccess = contactDataAccess;
        }
        public async Task<bool> Create(AddressBookCreateRequest request)
        {
            return await _contactDataAccess.CreateContact(request);
        }
    }
}
