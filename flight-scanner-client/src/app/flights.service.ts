import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
//import { catchError } from 'rxjs/operators';

import { Flight } from './flight';

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

    getFlights(origin: string, destination: string, passengerNum: string, dateRange: string, currency: string): Observable<{}> {
        console.log('evo me tu');
        this.flightsResponse$ = this.http.get(this.flightsUrl, httpOptions); //, {observe: 'body', responseType: 'json'}
        this.flightsResponse$.subscribe();
        return null;
    }
}