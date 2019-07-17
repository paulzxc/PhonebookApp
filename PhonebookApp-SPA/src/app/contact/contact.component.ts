import { Component, OnInit, Output } from '@angular/core';
import { Contact } from './contact.model';
import { ContactService } from './contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { publish, refCount } from 'rxjs/operators';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {

  contacts: Observable<Contact[]>;

  constructor(private contactService: ContactService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.contacts = this.contactService.getContacts();
  }

  onAddContact() {
    this.router.navigate(['new'], { relativeTo: this.route });
  }

}
