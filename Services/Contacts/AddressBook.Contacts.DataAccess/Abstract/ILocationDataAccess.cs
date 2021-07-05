using AddressBook.Contacts.Entities;
using AddressBook.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Abstract
{
    public interface ILocationDataAccess : IRepository<Location>
    {
    }
}
