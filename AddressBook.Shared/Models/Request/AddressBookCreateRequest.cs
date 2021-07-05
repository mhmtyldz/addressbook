namespace AddressBook.Shared.Models.Request
{
    public class AddressBookCreateRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int FirmId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContentOfInfo { get; set; }
        public int LocationId { get; set; }
    }
}
