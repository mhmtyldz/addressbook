using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.Entities
{
    public class Contact : BaseEntity
    {
        public Contact()
        {
            Uuid = Guid.NewGuid();
        }
        [Key]
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int FirmId { get; set; }

        [ForeignKey("FirmId")]
        public Firm Firm { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
