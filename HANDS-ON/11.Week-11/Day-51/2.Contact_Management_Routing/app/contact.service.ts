import { Injectable } from '@angular/core';
import { Contact } from '../Models/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  public contactsArray: Contact[] = [
  { id: 1, name: "Sai Bunny", email: "sai.bunny@gmail.com", phone: "+919000123456" },
  { id: 2, name: "Sravani Goud", email: "sravani.goud@gmail.com", phone: "+919012345678" },
  { id: 3, name: "Praveen Kumar", email: "praveen.kumar@gmail.com", phone: "+919123456789" },
  { id: 4, name: "Lavanya Chary", email: "lavanya.chary@gmail.com", phone: "+919234567890" },
  { id: 5, name: "Rahul Reddy", email: "rahul.reddy@gmail.com", phone: "+919345678901" },
  { id: 6, name: "Divya Rani", email: "divya.rani@gmail.com", phone: "+919456789012" },
  { id: 7, name: "Karthik Yadav", email: "karthik.yadav@gmail.com", phone: "+919567890123" }
];


 public getContacts():Contact[]{
  return this.contactsArray;
 }

 public addContact(contact: Contact): void{
    this.contactsArray.push(contact);
    console.log("Contact added successfully.");
 }

 public getContactById(id: number): Contact | undefined{
  return this.contactsArray.find(item=>item.id==id);
 }

  
}
