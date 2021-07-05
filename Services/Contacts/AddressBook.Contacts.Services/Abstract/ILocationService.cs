using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Abstract
{
    public interface ILocationService
    {
        Task<List<LocationListViewModel>> GetLocationList();
    }
}
