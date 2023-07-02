import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseAPIDto } from '@core/dto/response-api';

import { IAppState } from '@core/store/state/app.state';
import { ContactFilter, Contacts, IContact, UpdateContact } from '@models/contact';

import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private http: HttpClient, private store: Store<IAppState>) {}

  getContacts(filter: ContactFilter): Observable<Contacts> {
    return this.http
      .post<ResponseAPIDto<IContact[]>>('/contacts/search', filter)
      .pipe(map((response) => new Contacts().deserialize(response)));
  }

  updateContacts(data: UpdateContact) {
    return this.http.put<UpdateContact>(`/contacts`, data);
  }
}
