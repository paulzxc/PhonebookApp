using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhonebookApp.API.Models
{
  public class Contact
  {
    public int ContactId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
    public ICollection<PhoneNumber> PhoneNumbers { get; set; }
  }
}