import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../contact.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {

  @Input() contacts: Contact[];

  constructor() { }

  ngOnInit() {
  }

}
