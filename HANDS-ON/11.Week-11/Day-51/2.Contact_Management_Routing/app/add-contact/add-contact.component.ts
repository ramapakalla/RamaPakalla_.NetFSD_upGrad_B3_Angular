import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: 'add-contact.component.html',
  styleUrl: './add-contact.component.css'
})
export class AddContactComponent {

  newContact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(
    private service: ContactService,
    private router: Router
  ) {}

  addContact() {
    this.service.addContact(this.newContact);

    this.router.navigate(['/contacts']);
  }
}