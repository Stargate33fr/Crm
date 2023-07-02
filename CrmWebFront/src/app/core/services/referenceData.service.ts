import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ResponseAPIDto } from '@core/dto/response-api';
import { IAppState } from '@core/store/state/app.state';

import { ISelect, Select } from '@models/select';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ReferenceDataService {
  constructor(private http: HttpClient, private store: Store<IAppState>) {}

  getCivilities(): Observable<ISelect[]> {
    return this.http
      .get<ResponseAPIDto<ISelect[]>>(`/referenceData/civilities`)
      .pipe(map((response) => new Select().deserializeList(response.contenu)));
  }
}
