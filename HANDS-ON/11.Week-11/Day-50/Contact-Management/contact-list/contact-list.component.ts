import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { SearchPipe } from '../search.pipe';
import { PhonePipe } from '../phone.pipe';
import { StatusPipe } from '../status.pipe';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [FormsModule,SearchPipe,PhonePipe,StatusPipe,CommonModule],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
  contacts = [
  { name: 'rama pakalla', email: 'rama.pakalla@gmail.com', phone: '9876543210', status: true },
  { name: 'swathi udutha', email: 'swathi.udutha@yahoo.com', phone: '9123456780', status: false },
  { name: 'pranu reddy', email: 'pranu.reddy@outlook.com', phone: '9988776655', status: true },
  { name: 'meena kumari', email: 'meena.kumari@gmail.com', phone: '9090909090', status: false },
  { name: 'rahul sharma', email: 'rahul.sharma@gmail.com', phone: '9871234567', status: true },
  { name: 'anita joseph', email: 'anita.joseph@yahoo.com', phone: '9012345678', status: true },
  { name: 'vikram singh', email: 'vikram.singh@outlook.com', phone: '9345678123', status: false },
  { name: 'kavya nair', email: 'kavya.nair@gmail.com', phone: '9789012345', status: true },
  { name: 'rohit verma', email: 'rohit.verma@yahoo.com', phone: '9654321876', status: false },
  { name: 'pooja gupta', email: 'pooja.gupta@gmail.com', phone: '9123987654', status: true }
];

searchText:string = '';
limit: number = 5;

 toggleStatus(contact:any) {
  contact.status = !contact.status;
  
}
toggleLimit() {
  if (this.limit < this.contacts.length) {
    this.limit = this.contacts.length;
  } else {
    this.limit = 5;
  }
}

}
