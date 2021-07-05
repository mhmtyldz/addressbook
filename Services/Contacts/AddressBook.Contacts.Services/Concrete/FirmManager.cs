using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.Models;
using AddressBook.Shared.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Concrete
{
    public class FirmManager : IFirmService
    {
        private readonly IFirmDataAccess _firmDataAccess;
        private readonly IMapper _mapper;
        public FirmManager(IFirmDataAccess firmDataAccess,IMapper mapper)
        {
            _firmDataAccess = firmDataAccess;
            _mapper = mapper;
        }
        public async Task<List<FirmListViewModel>> GetFirmList()
        {
            var firms =await _firmDataAccess.GetAllAsync();
            return _mapper.Map<List<FirmListViewModel>>(firms.Result.ToList());
        }
    }
}
