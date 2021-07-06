using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.DataAccess.Context.EntityFramework;
using AddressBook.Contacts.DataAccess.Repository.EntityFramework;
using AddressBook.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Concrete
{
    public class ContactInfoDataAccess : EntityFrameworkRepository<AddressBookDbContext, ContactInformation>, IContactInfoDataAccess
    {
        AddressBookDbContext _context;

        public ContactInfoDataAccess(AddressBookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
