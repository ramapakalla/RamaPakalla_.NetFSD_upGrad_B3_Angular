import { Component } from '@angular/core';
import { ContactService } from '../contact.service';
import { Contact } from '../../Models/Contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './contact-detail.component.html',
  styleUrl: './contact-detail.component.css'
})
export class ContactDetailComponent {
  public contactObj : Contact | undefined;

  constructor(private contactService:ContactService){
    this.contactObj = this.contactService.getContactById(1);
  }

}
