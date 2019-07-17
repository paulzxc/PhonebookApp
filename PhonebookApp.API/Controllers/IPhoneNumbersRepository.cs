using System.Collections.Generic;
using System.Threading.Tasks;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Controllers
{
  public interface IPhoneNumbersRepository
  {
    Task<PhoneNumber> AddPhoneNumber(PhoneNumber phoneNumber);
  }
}