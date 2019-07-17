using System.ComponentModel.DataAnnotations;

namespace PhonebookApp.API.DTOs
{
  public class ContactToUpdateDTO
  {
    [Required]
    public string ContactId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "The property {0} doesn't have more than {1} elements")]
    public string[] PhoneNumbers { get; set; }
  }
}