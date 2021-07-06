using AddressBook.Reports.Models;
using AddressBook.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Reports.Services.Interfaces
{
    public interface INumberOfPeopleService
    {
        Task<bool> Update(NumberOfPeopleAtThatLocationCommand numberOfPeople);
    }
}
