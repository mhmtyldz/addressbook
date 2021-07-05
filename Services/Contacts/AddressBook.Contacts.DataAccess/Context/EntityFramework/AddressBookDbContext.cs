using AddressBook.Contacts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Context.EntityFramework
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Firm> Firm { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactInformation> ContactInformation { get; set; }
    }
}
