using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.DataAccess.Context.EntityFramework;
using AddressBook.Contacts.DataAccess.Repository.EntityFramework;
using AddressBook.Contacts.Entities;
using AddressBook.Shared.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Concrete
{
    public class ContactDataAccess : EntityFrameworkRepository<AddressBookDbContext, Contact>, IContactDataAccess
    {
        AddressBookDbContext _context;

        public ContactDataAccess(AddressBookDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CreateContact(AddressBookCreateRequest request)
        {
            var result = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var contact = new Contact
                    {
                        FirmId = request.FirmId,
                        Name = request.Name,
                        LastName = request.LastName,
                    };
                    var addedContact = await _context.AddAsync(contact);
                    await _context.SaveChangesAsync();
                    if (addedContact != null && addedContact.Entity != null)
                    {
                        var contactInfo = new ContactInformation
                        {
                            ContactId = addedContact.Entity.Uuid,
                            ContentOfInfo = request.ContentOfInfo,
                            EmailAddress = request.EmailAddress,
                            LocationId = request.LocationId,
                            PhoneNumber = request.PhoneNumber
                        };
                        var addedContactInfo = await _context.AddAsync(contactInfo);
                        await _context.SaveChangesAsync();
                        if (addedContactInfo != null && addedContactInfo.Entity != null)
                        {
                            transaction.Commit();
                            result = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                }

            }
            return result;
        }
    }
}
