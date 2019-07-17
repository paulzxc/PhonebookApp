using System.ComponentModel.DataAnnotations.Schema;

namespace PhonebookApp.API.Models
{
  public class PhoneNumber
  {
    public int PhoneNumberId { get; set; }
    public string Number { get; set; }

    //Foreign key for Standard
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
  }
}