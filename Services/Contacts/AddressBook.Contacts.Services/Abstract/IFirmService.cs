using AddressBook.Shared.Models;
using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Abstract
{
    public interface IFirmService
    {
        Task<List<FirmListViewModel>> GetFirmList();
    }
}
