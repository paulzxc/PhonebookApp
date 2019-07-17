using Microsoft.EntityFrameworkCore;
using PhonebookApp.API.Models;

namespace PhonebookApp.API.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
  }
}