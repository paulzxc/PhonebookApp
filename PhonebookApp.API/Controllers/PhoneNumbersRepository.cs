using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.API.Data;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Controllers
{
  public class PhoneNumbersRepository : IPhoneNumbersRepository
  {
    private readonly DataContext _context;
    public PhoneNumbersRepository(DataContext context)
    {
      _context = context;

    }
    public async Task<PhoneNumber> AddPhoneNumber(PhoneNumber phoneNumber)
    {
      await _context.PhoneNumbers.AddAsync(phoneNumber);
      await _context.SaveChangesAsync();

      return phoneNumber;
    }

  }
}