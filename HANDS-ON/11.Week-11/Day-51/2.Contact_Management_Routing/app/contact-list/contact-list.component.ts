import { Component } from '@angular/core';
import { Contact } from '../../Models/Contact';
import { ContactService } from '../contact.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
    public  contactsArray:Contact[]  =  [];
    newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

    constructor(private contactService:ContactService){
      this.contactsArray = contactService.getContacts();

    }
  
  addContact(): void {
    if (!this.newContact.name || !this.newContact.email || !this.newContact.phone) {
      alert('Fill all fields');
      return;
    }
    else{
      
      this.contactService.addContact(this.newContact);
    }
  }
 

}
