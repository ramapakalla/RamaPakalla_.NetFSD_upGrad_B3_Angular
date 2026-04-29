import { Component,ChangeDetectorRef,OnInit } from '@angular/core';
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
export class ContactListComponent implements OnInit {

    public  data:Contact[]  =  [];

    newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

    constructor(private contactService:ContactService){}
   
    ngOnInit():void
  {
    this.getContactsClick();
  }


 getContactsClick():void{
  this.contactService.getContacts().subscribe((response) =>  
    {     
      console.log(response);
      this.data = response;
    });
 }

 addContactClick(): void {
  this.contactService.addContact(this.newContact).subscribe({
    next: () => {
      this.getContactsClick();
      this.resetForm();
    },
    error: err => console.error(err)
  });
}

 editContactClick(contactObj:Contact):void{
  this.newContact = {...contactObj};
 }

updateContactClick() {
  if (!this.newContact.id || this.newContact.id === 0) {
    alert("Select a contact using Edit before updating");
    return;
  }

  this.contactService.updateContact(this.newContact).subscribe({
    next: () => {
      this.getContactsClick();
      this.resetForm();
    },
    error: err => console.error(err)
  });
}

 deleteContactClick(id:number):void{
  this.contactService.deleteContact(id).subscribe({
    next:(res:any)=>{
      this.getContactsClick();
    }
  });
 }
 
 resetForm() {
    this.newContact = { id: 0, name: '', email: '', phone: '' };
  }

}
