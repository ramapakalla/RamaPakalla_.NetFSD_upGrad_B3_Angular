import { Routes } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';


export const routes: Routes = [
    { path : "contacts", component :  ContactListComponent},
    { path : "add-contact", component :  AddContactComponent},
    { path : "contact/:id", component : ContactDetailComponent},
    { path: '**', redirectTo: 'contacts' }
];
