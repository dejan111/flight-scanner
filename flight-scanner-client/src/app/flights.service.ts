import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
//import { catchError } from 'rxjs/operators';

import { Flight } from './flight';
import { FlightRequest } from './flightRequest';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

@Injectable()
export class FlightsService{
    flightsUrl = '/api/flights/test';
    flightsResponse$: Observable<{}>;

    constructor(private http: HttpClient) {
        
    }

    getFlights(flightRequest: FlightRequest): Observable<Flight[]> {
        console.log('evo me tu');

        return this.http.post<Flight[]>(this.flightsUrl, JSON.stringify(flightRequest), httpOptions);
    }
}