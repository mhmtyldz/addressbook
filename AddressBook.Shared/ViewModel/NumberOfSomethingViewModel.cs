using System.Collections.Generic;

namespace AddressBook.Shared.ViewModel
{
    public class NumberOfSomethingViewModel
    {
        public List<NumberOfPeopleViewModel> NumberOfPeople { get; set; }
        public List<NumberOfPhoneNumberViewModel> NumberOfPhoneNumber { get; set; }
    }

    public class NumberOfPeopleViewModel
    {
        public int Count { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
    public class NumberOfPhoneNumberViewModel
    {
        public int Count { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
