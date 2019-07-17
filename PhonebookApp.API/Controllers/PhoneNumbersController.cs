using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhonebookApp.API.Controllers
{
  [Route("api/contacts/{ContactId:int}/phonenumbers")]
  [ApiController]
  public class PhoneNumbersController : ControllerBase
  {
    private readonly IPhoneNumbersRepository _phoneNumberRepo;
    public PhoneNumbersController(IPhoneNumbersRepository phoneNumberRepo)
    {
      _phoneNumberRepo = phoneNumberRepo;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetPhoneNumbers(int contactId)
    // {
    //   var phonenumbers = await _phoneNumberRepo.GetPhoneNumbers(contactId);

    //   return Ok(phonenumbers);
    // }
  }
}