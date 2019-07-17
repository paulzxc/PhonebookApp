using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.API.Data;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Controllers
{
  public class ContactsRepository : IContactsRepository
  {
    private readonly DataContext _context;
    public ContactsRepository(DataContext context)
    {
      _context = context;

    }
    public async Task<Contact> AddContact(Contact contact)
    {
      await _context.Contacts.AddAsync(contact);
      await _context.SaveChangesAsync();

      return contact;
    }

    public async Task<bool> ContactExists(string name)
    {
      if (await _context.Contacts.AnyAsync(x => x.Name == name))
        return true;

      return false;
    }

    public async Task<Contact> DeleteContact(int contactId)
    {
      var contactToDelete = await _context.Contacts.Include(x => x.PhoneNumbers).FirstOrDefaultAsync(x => x.ContactId == contactId);

      // Remove phone numbers associated with contact
      foreach (var phoneNumber in contactToDelete.PhoneNumbers)
      {
        _context.PhoneNumbers.Remove(phoneNumber);
      }

      _context.Entry(contactToDelete).State = EntityState.Deleted;

      await _context.SaveChangesAsync();
      return contactToDelete;
    }

    public async Task<Contact> GetContact(int contactId)
    {
      var contact = await _context.Contacts.Include(x => x.PhoneNumbers).FirstOrDefaultAsync(x => x.ContactId == contactId);

      return contact;
    }

    public async Task<List<Contact>> GetContacts()
    {
      var contactsToFetch = await _context.Contacts.Include(x => x.PhoneNumbers).ToListAsync();

      return contactsToFetch;
    }

    public async Task<Contact> UpdateContact(Contact contact)
    {
      var contactToUpdate = await _context.Contacts.Include(x => x.PhoneNumbers).FirstOrDefaultAsync(x => x.ContactId == contact.ContactId);
      if (contactToUpdate == null) return null;

      // Remove phone numbers associated with contact
      foreach (var phoneNumber in contactToUpdate.PhoneNumbers)
      {
        _context.PhoneNumbers.Remove(phoneNumber);
      }

      foreach (var phoneNumber in contact.PhoneNumbers)
      {
        var newPhoneNumber = new PhoneNumber
        {
          Number = phoneNumber.Number
        };
        contactToUpdate.PhoneNumbers.Add(newPhoneNumber);
      }
      _context.Entry(contactToUpdate).CurrentValues.SetValues(contact);
      await _context.SaveChangesAsync();
      return contact;
    }
  }
}