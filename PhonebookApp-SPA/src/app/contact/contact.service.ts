import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Contact } from './contact.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>('http://localhost:5000/api/contacts');
  }

  getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(`http://localhost:5000/api/contacts/${id}`);
  }

  addContact(formValues: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post('http://localhost:5000/api/contacts/addcontact', formValues, httpOptions);
  }

  updateContact(formValues: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post('http://localhost:5000/api/contacts/updatecontact', formValues, httpOptions);
  }

  deleteContact(id: number) {
    return this.http.delete('http://localhost:5000/api/contacts/deletecontact/' + id);
  }
}
