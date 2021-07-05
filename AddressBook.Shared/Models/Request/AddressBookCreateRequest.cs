using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Shared.Models.Request
{
    public class AddressBookCreateRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Firm")]
        public int FirmId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Phone Number")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage = "Email Address format is incorrect")]
        public string EmailAddress { get; set; }
        public string ContentOfInfo { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Location")]
        public int LocationId { get; set; }
    }
}
