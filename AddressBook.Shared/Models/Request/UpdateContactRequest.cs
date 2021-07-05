using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Models.Request
{
    public class UpdateContactRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
