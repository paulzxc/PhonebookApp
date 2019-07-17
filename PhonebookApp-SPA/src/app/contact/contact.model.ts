export class Contact {
  public contactId: number;
  public name: string;
  public email: string;
  public phoneNumbers: any;

  constructor(contactId: number, name: string, email: string, phoneNumbers: string[]) {
    this.contactId = contactId;
    this.name = name;
    this.email = email;
    this.phoneNumbers = phoneNumbers;
  }
}