using System.Collections.Generic;
using System.Threading.Tasks;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Controllers
{
  public interface IContactsRepository
  {
    Task<Contact> AddContact(Contact contact);
    Task<bool> ContactExists(string name);
    Task<List<Contact>> GetContacts();
    Task<Contact> UpdateContact(Contact contact);

    Task<Contact> DeleteContact(int contactId);

    Task<Contact> GetContact(int contactId);
  }
}