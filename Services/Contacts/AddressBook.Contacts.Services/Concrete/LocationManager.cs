using AddressBook.Contacts.DataAccess.Abstract;
using AddressBook.Contacts.Services.Abstract;
using AddressBook.Shared.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Services.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDataAccess _locationDataAccess;
        private readonly IMapper _mapper;

        public LocationManager(ILocationDataAccess locationDataAccess, IMapper mapper)
        {
            _locationDataAccess = locationDataAccess;
            _mapper = mapper;
        }
      
        public async Task<List<LocationListViewModel>> GetLocationList()
        {
            var locations = await _locationDataAccess.GetAllAsync();
            return _mapper.Map<List<LocationListViewModel>>(locations.Result.ToList());
        }
    }
}
