import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Flight } from './flight';
import { FlightRequest } from './flightRequest';

const httpOptions = {
    headers: new HttpHeaders({
      ContentType:  'application/json',
      observe: 'body',
      responseType: 'json'
    })
  };

@Injectable()
export class FlightsService{
    flightsUrl = '/api/flights/flights';
    flightsResponse$: Observable<{}>;

    constructor(private http: HttpClient) {
    }

    // getFlights(flightRequest: FlightRequest): Observable<Flight[]> {
    //     console.log('evo me tu');

    //     return this.http.post<Flight[]>(this.flightsUrl, JSON.stringify(flightRequest), httpOptions);
    // }

    getFlights(flightRequest: FlightRequest): Observable<Flight[]> {
      console.log('evo me tu');

      let params = new HttpParams();
      params = params.append('Origin', flightRequest.origin);
      params = params.append('Destination', flightRequest.destination);
      params = params.append('DepartureDate', flightRequest.departureDate);
      params = params.append('ReturnDate', flightRequest.returnDate);
      params = params.append('PassengersNum', flightRequest.passengersNum.toString());
      params = params.append('Currency', flightRequest.currency);

      return this.http.get<Flight[]>(this.flightsUrl, {params: params});
  }
}