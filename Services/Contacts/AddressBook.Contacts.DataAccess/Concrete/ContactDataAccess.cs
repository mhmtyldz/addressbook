using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.DataAccess.Context.EntityFramework;
using AddressBook.Contacts.DataAccess.Repository.EntityFramework;
using AddressBook.Contacts.Entities;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AddressBookCreateViewModel> CreateContact(AddressBookCreateRequest request)
        {
            var result = new AddressBookCreateViewModel();

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
                            result.ContactId = contactInfo.ContactId.ToString();
                            result.LocationId = contactInfo.LocationId;
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

        public async Task<bool> DeleteContactAndContactInfo(string id)
        {
            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var uuid = Guid.Parse(id);
                    var contactInfo = await _context.ContactInformation.FirstOrDefaultAsync(x => x.ContactId == uuid);
                    if (contactInfo != null)
                    {
                        var deletedContactInfo = _context.ContactInformation.Remove(contactInfo);

                        await _context.SaveChangesAsync();
                        if (deletedContactInfo != null && deletedContactInfo.Entity != null)
                        {
                            var contact = await _context.Contact.FirstOrDefaultAsync(x => x.Uuid == uuid);
                            var deletedContact = _context.Contact.Remove(contact);
                            await _context.SaveChangesAsync();
                            transaction.Commit();
                            result = true;
                        }
                    }
                    else
                    {
                        var contact = await _context.Contact.FirstOrDefaultAsync(x => x.Uuid == uuid);
                        var deletedContact = _context.Contact.Remove(contact);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        result = true;
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

        public async Task<List<ContactListViewModel>> GetAllWithContactInfo()
        {
            var result = new GetManyResult<ContactListViewModel>();

            var contacts = _context.Contact.Include(x => x.ContactInformation).ThenInclude(x => x.Location).Select(x => new ContactListViewModel
            {

                EmailAddress = x.ContactInformation.EmailAddress,
                Lastname = x.LastName,
                Name = x.Name,
                PhoneNumber = x.ContactInformation.PhoneNumber,
                Location = x.ContactInformation.Location.Name,
                Id = x.Uuid.ToString()
            }).ToList();

            return contacts;
        }
    }
}
