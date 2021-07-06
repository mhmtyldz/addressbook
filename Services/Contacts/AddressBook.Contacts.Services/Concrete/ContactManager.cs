using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public ContactManager(IContactDataAccess contactDataAccess, IMapper mapper)
        {
            _contactDataAccess = contactDataAccess;
            _mapper = mapper;
        }
        public async Task<bool> Create(AddressBookCreateRequest request)
        {
            return await _contactDataAccess.CreateContact(request);
        }

        public async Task<bool> Delete(string id)
        {
            var result =await _contactDataAccess.DeleteContactAndContactInfo(id);
            return result;
        }

        public async Task<List<ContactListViewModel>> GetAll()
        {
            return await _contactDataAccess.GetAllWithContactInfo();
        }

        public async Task<ContactDetailViewModel> GetContact(string id)
        {
            var guid = Guid.Parse(id);
            var contact = await _contactDataAccess.FindAsync(x => x.Uuid == guid);
            return _mapper.Map<ContactDetailViewModel>(contact.Entity);
        }
        
        public async Task<bool> Update(UpdateContactRequest request)
        {
            var result = false;

            try
            {
                var id = Guid.Parse(request.Id);
                var contact = await _contactDataAccess.FindAsync(x => x.Uuid == id);
                if (contact.Success && contact.Entity != null)
                {
                    contact.Entity.Name = request.Name;
                    contact.Entity.LastName = request.LastName;

                    var updatedContact = await _contactDataAccess.UpdateAsync(contact.Entity);
                    if (updatedContact.Success && updatedContact.Entity != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
