using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Entities
{
    public class ContactInformation : BaseEntity
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContentOfInfo { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
    }
}
