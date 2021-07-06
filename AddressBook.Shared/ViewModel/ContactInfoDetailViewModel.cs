using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.ViewModel
{
    public class ContactInfoDetailViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContentOfInfo { get; set; }
        public int LocationId { get; set; }
        public Guid ContactId{ get; set; }
    }
}
