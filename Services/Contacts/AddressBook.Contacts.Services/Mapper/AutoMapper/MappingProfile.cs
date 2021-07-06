using AddressBook.Contacts.Entities;
using AddressBook.Shared.Models;
using AddressBook.Shared.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Firm, FirmListViewModel>().ReverseMap();
            CreateMap<Location, LocationListViewModel>().ReverseMap();
            CreateMap<Contact, ContactDetailViewModel>().ReverseMap();
            CreateMap<ContactInformation, ContactInfoDetailViewModel>().ReverseMap();
        }
    }
}
