import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { FlightsService } from './flights.service';
import { Flight } from './flight';
import { FlightRequest } from './flightRequest';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [FlightsService],
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  origin : string;
  destination : string;
  flights: Flight[];
  flightRequest: FlightRequest = {};
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
    let dateRangeArray: Array<string> = this.flightSearchForm.value.dateRangeInput;
    
    this.flightRequest.origin = this.flightSearchForm.value.originInput;
    this.flightRequest.destination = this.flightSearchForm.value.destinationInput;
    this.flightRequest.passengersNum = this.flightSearchForm.value.passengerNumInput;
    this.flightRequest.currency = this.flightSearchForm.value.currencyInput;
    this.flightRequest.departureDate = dateRangeArray[0];
    this.flightRequest.returnDate = dateRangeArray[1];

    // this.flights = this.service.getFlights(this.flightRequest).subscribe();
    let test = this.service.getFlights(this.flightRequest).subscribe();
    console.log(test);
  };
}
