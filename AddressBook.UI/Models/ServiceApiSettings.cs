using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Models
{
    public class ServiceApiSettings
    {
        public string GatewayBaseUri { get; set; }
        public ServiceApi Contacts { get; set; }

        public ServiceApi Reports { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
