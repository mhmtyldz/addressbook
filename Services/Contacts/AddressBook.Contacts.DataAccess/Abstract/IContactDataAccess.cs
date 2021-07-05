﻿using AddressBook.Contacts.Entities;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Abstract
{
    public interface IContactDataAccess : IRepository<Contact>
    {
        Task<bool> CreateContact(AddressBookCreateRequest request);
    }
}
