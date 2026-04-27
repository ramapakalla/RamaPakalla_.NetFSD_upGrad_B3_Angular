import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value:number): string {
    if(!value){
      return '';
    }

    const phone = value.toString();

    if(phone.length != 10){
      return phone;
    }
    return phone.substring(0,3) + '-' + 
    phone.substring(3,6) + '-' + phone.substring(6);
    
  }

}
