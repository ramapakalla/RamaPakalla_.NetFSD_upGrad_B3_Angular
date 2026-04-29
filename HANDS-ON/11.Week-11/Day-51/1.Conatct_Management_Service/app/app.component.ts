import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,ContactListComponent,ContactDetailComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Contact-Management';
}
