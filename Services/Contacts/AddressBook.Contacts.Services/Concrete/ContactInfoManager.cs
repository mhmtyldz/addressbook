using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.Entities;
using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Models.Request;
using AddressBook.Shared.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDataAccess _contactInfoDataAccess;
        private readonly IMapper _mapper;
        public ContactInfoManager(IContactInfoDataAccess contactInfoDataAccess, IMapper mapper)
        {
            _contactInfoDataAccess = contactInfoDataAccess;
            _mapper = mapper;
        }

        public async Task<DeleteContactInfoViewModel> DeleteContactInfo(int id)
        {
            var result = new DeleteContactInfoViewModel();
            var contactInfo = await _contactInfoDataAccess.FindAsync(x => x.Id == id);
            if (contactInfo.Success && contactInfo.Entity != null)
            {
                var deletedContactInfo = await _contactInfoDataAccess.DeleteAsync(contactInfo.Entity);
                if (deletedContactInfo.Success)
                {
                    result.LocationId = contactInfo.Entity.LocationId;
                    result.ContactId = contactInfo.Entity.ContactId.ToString();
                }
            }
            return result;
        }

        public async Task<ContactInfoDetailViewModel> GetContactInfo(string id)
        {
            var result = new ContactInfoDetailViewModel();
            var contactid = Guid.Parse(id);
            var contactInfo = await _contactInfoDataAccess.FindAsync(x => x.ContactId == contactid);
            if (contactInfo.Success && contactInfo.Entity != null)
                result = _mapper.Map<ContactInfoDetailViewModel>(contactInfo.Entity);
            else
                result.ContactId = contactid;
            return result;
        }

        public async Task<bool> Update(UpdateContactInfoRequest request)
        {
            var result = false;

            try
            {
                var contactInfo = await _contactInfoDataAccess.FindAsync(x => x.Id == request.Id);
                if (contactInfo.Success)
                {
                    if (contactInfo.Entity != null)
                    {
                        contactInfo.Entity.EmailAddress = request.EmailAddress;
                        contactInfo.Entity.PhoneNumber = request.PhoneNumber;
                        contactInfo.Entity.LocationId = request.LocationId;
                        contactInfo.Entity.ContentOfInfo = request.ContentOfInfo;

                        var updatedContactInfo = await _contactInfoDataAccess.UpdateAsync(contactInfo.Entity);
                        if (updatedContactInfo.Success && updatedContactInfo.Entity != null)
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        var contactInfoInsert = new ContactInformation
                        {
                            ContactId = Guid.Parse(request.ContactId),
                            ContentOfInfo = request.ContentOfInfo,
                            EmailAddress = request.EmailAddress,
                            LocationId = request.LocationId,
                            PhoneNumber = request.PhoneNumber
                        };
                        var insertedContactInfo = await _contactInfoDataAccess.AddAsync(contactInfoInsert);
                        if (insertedContactInfo.Success && insertedContactInfo.Entity != null)
                        {
                            result = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
