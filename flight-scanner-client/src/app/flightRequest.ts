export interface FlightRequest {
    origin ? : string;
    destination ? : string;
    departureDate ? : string;
    returnDate ? : string;
    passengersNum ? : number;
    currency ? : string;
}