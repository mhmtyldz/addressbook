using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Messages
{
    public class NumberOfPeopleAtThatLocationCommand
    {
        public string ContactId { get; set; }
        public int LocationId { get; set; }
        public ProcessType  ProcessType{ get; set; }
    }
}
