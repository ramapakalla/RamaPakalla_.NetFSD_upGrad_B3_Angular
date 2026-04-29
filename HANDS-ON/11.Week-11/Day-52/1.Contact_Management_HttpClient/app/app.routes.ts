import { Routes } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component'; 
import { authGuard } from './auth.guard';

export const routes: Routes = [

  { path: 'contacts', component: ContactListComponent },   

  {
    path: 'add-contact',
    component: AddContactComponent,
    canActivate: [authGuard]  
  },

  {
    path: 'contact/:id',
    component: ContactDetailComponent,
    canActivate: [authGuard]  
  },

  { path: '**', redirectTo: 'contacts' }
];