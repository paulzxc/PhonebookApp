using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonebookApp.API.DTOs;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Controllers
{
  [Route("api/contacts")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IContactsRepository _contactRepo;
    private readonly IPhoneNumbersRepository _phoneNumberRepo;
    public ContactsController(IContactsRepository contactRepo, IPhoneNumbersRepository phoneNumberRepo)
    {
      _contactRepo = contactRepo;
      _phoneNumberRepo = phoneNumberRepo;
    }

    [HttpPost("addcontact")]
    public async Task<IActionResult> AddContact(ContactToAddDTO contactToAddDTO)
    {
      if (await _contactRepo.ContactExists(contactToAddDTO.Name))
        return BadRequest("Contact already exists");

      var phoneNumberList = new List<PhoneNumber>();

      foreach (var phoneNumber in contactToAddDTO.PhoneNumbers)
      {
        phoneNumberList.Add(new PhoneNumber()
        {
          Number = phoneNumber
        });
      }

      var contactToAdd = new Contact
      {
        Name = contactToAddDTO.Name,
        Email = contactToAddDTO.Email,
        PhoneNumbers = phoneNumberList
      };

      var createdContact = await _contactRepo.AddContact(contactToAdd);


      // var phoneNumberList = contactToAddDTO.PhoneNumbers;

      // foreach (var phoneNumber in phoneNumberList)
      // {

      //   var phoneNumberToAdd = new PhoneNumber
      //   {
      //     ContactId = createdContact.ContactId,
      //     Number = phoneNumber
      //   };

      //   var createdPhoneNumber = await _phoneNumberRepo.AddPhoneNumber(phoneNumberToAdd);
      // }

      return Ok(createdContact);
    }

    [HttpPost("updatecontact")]
    public async Task<IActionResult> UpdateContact(ContactToUpdateDTO contactToUpdateDTO)
    {
      var contactToUpdateList = new List<PhoneNumber>();
      foreach (var phoneNumber in contactToUpdateDTO.PhoneNumbers)
      {
        contactToUpdateList.Add(new PhoneNumber()
        {
          Number = phoneNumber
        });
      }

      var contactToUpdate = new Contact
      {
        ContactId = Int32.Parse(contactToUpdateDTO.ContactId),
        Name = contactToUpdateDTO.Name,
        Email = contactToUpdateDTO.Email,
        PhoneNumbers = contactToUpdateList
      };


      var updatedContact = await _contactRepo.UpdateContact(contactToUpdate);
      if (updatedContact != null)
      {
        return Ok(updatedContact);
      }
      return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
      var contacts = await _contactRepo.GetContacts();
      return Ok(contacts);
    }

    [HttpDelete("deletecontact/{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
      var deletedContact = await _contactRepo.DeleteContact(id);
      return StatusCode(204);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
      var contact = await _contactRepo.GetContact(id);
      return Ok(contact);
    }

  }
}