import { Injectable } from '@angular/core';
import { Contact } from '../Models/Contact';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

    readonly API_URL:string = "https://localhost:7110/api/Contacts/";
  
    constructor(private httpClient:HttpClient){}
  
    public getContacts(){
      return this.httpClient.get<Contact[]>(this.API_URL);
    }

    addContact(contact:Contact){
   
    return this.httpClient.post<Contact>(this.API_URL,contact);
 }

  getContactById(id:number){
  return this.httpClient.get<Contact>(this.API_URL+id);
 }

 updateContact(contact:Contact){
  return this.httpClient.put(this.API_URL+contact.id,contact);
 }

 deleteContact(id:number){
  return this.httpClient.delete(this.API_URL+id);
 }

  
}

 

  

