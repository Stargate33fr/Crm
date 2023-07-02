import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ResponseAPIDto } from '@core/dto/response-api';
import { IAppState } from '@core/store/state/app.state';

import { IUser, IUserLight, User, UserLight } from '@models/user';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private store: Store<IAppState>) {}

  getUserByEmail(email: string): Observable<User> {
    return this.http.get<ResponseAPIDto<IUser>>(`/user/${email}`).pipe(map((response) => new User().deserialize(response.contenu)));
  }

  getUsersLight(): Observable<UserLight[]> {
    return this.http
      .get<ResponseAPIDto<IUserLight[]>>(`/user/usersLight`)
      .pipe(map((response) => new UserLight().deserializeList(response.contenu)));
  }
}
