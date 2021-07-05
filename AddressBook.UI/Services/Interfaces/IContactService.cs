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
    }
}
