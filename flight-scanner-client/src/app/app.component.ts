import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  origin : string;
  destination : string;

  flightSearchForm = new FormGroup({
    originInput: new FormControl(''),
    destinationInput: new FormControl(''),
    currencyInput: new FormControl(''),
    dateRangeInput: new FormControl(''),
    passengerNumInput: new FormControl('')
  });

  currencies = this.getCurrencies();
  currencyInputName = 'currencyInput'

  title = 'Flight scanner';
  minDate = this.getYesterday();

  getCurrencies(){
    return ['USD', 'EUR', 'HRK']
  }
  
  getYesterday() {
    let minDate = new Date();
    minDate.setDate(minDate.getDate() - 1);

    return minDate;
  }

  onSubmit(){
    console.log(this.flightSearchForm.value);
  };
}
