import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { FlightsService } from './flights.service';
import { Flight } from './flight';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [FlightsService],
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  origin : string;
  destination : string;
  flights: Flight[];
  service;

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

  constructor(service: FlightsService){
    this.service = service;
  }

  getCurrencies(){
    return ['USD', 'EUR', 'HRK']
  }
  
  getYesterday() {
    let minDate = new Date();
    minDate.setDate(minDate.getDate() - 1);

    return minDate;
  }

  onSubmit(){
    this.flights = this.service.getFlights();
    console.log(this.flightSearchForm.value);
  };
}
