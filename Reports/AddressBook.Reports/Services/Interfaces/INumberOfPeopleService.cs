using AddressBook.Reports.Models;
using AddressBook.Shared.Messages;
using AddressBook.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Reports.Services.Interfaces
{
    public interface INumberOfPeopleService
    {
        Task Update(NumberOfPeopleAtThatLocationCommand numberOfPeople);
        Task<NumberOfSomethingViewModel> GetNumberOfSomethingInfo();
    }
}
