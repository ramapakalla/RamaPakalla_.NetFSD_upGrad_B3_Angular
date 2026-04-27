import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(contacts: any[],searchText:string): any[] {
    if(!contacts || !searchText){
      return contacts
    }

    const search = searchText.toLowerCase().trim();

    return contacts.filter(contact=>{
      const name = contact.name.toLowerCase();
      const email = contact.email.toLowerCase();

      return name.includes(search) || email.includes(search);
    });
  }

}
