import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact.model';
import { ContactService } from '../contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap, tap, flatMap } from 'rxjs/operators';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Observable, empty } from 'rxjs';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.scss']
})
export class ContactDetailComponent implements OnInit {

  // contact: Contact;
  editMode = false;
  contactDetailForm: FormGroup;

  constructor(private contactService: ContactService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.contactDetailForm = new FormGroup({
      ContactId: new FormControl(''),
      Name: new FormControl('', [Validators.required]),
      Email: new FormControl('', [Validators.required, Validators.email]),
      PhoneNumbers: new FormArray([this.createPhoneNumber()])
    });


    this.route.paramMap
      .pipe(
        switchMap(params => {
          if (!params.get('id')) {
            return empty();
          }
          this.editMode = true;
          return this.contactService.getContact(+params.get('id'));
        })
      ).subscribe(c => {
        if (!c) { return; }
        this.contactDetailForm.controls['ContactId'].setValue(c.contactId);
        this.contactDetailForm.controls['Name'].setValue(c.name);
        this.contactDetailForm.controls['Email'].setValue(c.email);
        this.contactDetailForm.setControl('PhoneNumbers', this.setExistingPhone(c.phoneNumbers));
      });
  }

  createPhoneNumber() {
    return new FormControl('', [Validators.required]);
  }

  setExistingPhone(phoneNumbers: any): FormArray {
    const formArray = new FormArray([]);
    phoneNumbers.forEach(p => {
      formArray.push(new FormControl(p.number));
    });
    return formArray;
  }
  get PhoneNumbers() {
    return this.contactDetailForm.get('PhoneNumbers') as FormArray;
  }

  onDelete() {
    this.contactService.deleteContact(this.contactDetailForm.controls['ContactId'].value).subscribe(c => {
      alert('Contact deleted!');
      this.router.navigate(['contacts']);
    });
  }

  deleteNumber(i: number) {
    this.PhoneNumbers.removeAt(i);
  }

  addNumber() {
    this.PhoneNumbers.push(this.createPhoneNumber());
  }

  onSaveContact() {
    this.contactService.addContact(this.contactDetailForm.value).subscribe(c => {
      alert('Contact saved!');
      this.router.navigate(['contacts']);
    });
  }

  onEditContact() {
    this.contactService.updateContact(this.contactDetailForm.value).subscribe(c => {
      alert('Contact saved!');
      this.router.navigate(['contacts']);
    });
  }

  onCancel() {
    this.router.navigate(['contacts']);
  }
}