import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ContactService } from '../contact.service';
import { Contact } from '../../Models/Contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent {

  public contactObj: Contact | undefined;

  constructor(
    private activatedRoute: ActivatedRoute,
    private contactService: ContactService
  ) {}

  ngOnInit() {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.contactService.getContactById(id).subscribe(res => {
      this.contactObj = res;
    });
  }
}