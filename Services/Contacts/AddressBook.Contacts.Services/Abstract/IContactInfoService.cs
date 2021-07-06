using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Abstract
{
    public interface IContactInfoService
    {
        Task<ContactInfoDetailViewModel> GetContactInfo(string id);
        Task<bool> Update(UpdateContactInfoRequest request);
        Task<DeleteContactInfoViewModel> DeleteContactInfo(int id);
    }
}
