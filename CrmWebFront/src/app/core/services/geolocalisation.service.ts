import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseAPIDto } from '@core/dto/response-api';
import { environment } from '@environment';
import { ISearch } from '@models/select';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class GeolocalisationService {
  constructor(private http: HttpClient) {}

  localisations(recherche: string): Observable<ISearch[]> {
    return this.http
      .post<ResponseAPIDto<ISearch[]>>('/geolocalisation/getLocalisations', { recherche })
      .pipe(map((response) => response.contenu));
  }

  localisationByGoogle(adresse: string, cp: string, ville: string) {
    return this.http
      .get(
        `https://maps.googleapis.com/maps/api/geocode/json?components=route:${adresse} ${cp} ${ville}|country:France&key=${environment.context.map.apiKey}`,
      )
      .pipe(map((response) => response));
  }
}
