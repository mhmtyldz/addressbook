using AddressBook.Shared.Models.Request;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Abstract
{
    public interface IContactService
    {
        Task<bool> Create(AddressBookCreateRequest request);
    }
}
