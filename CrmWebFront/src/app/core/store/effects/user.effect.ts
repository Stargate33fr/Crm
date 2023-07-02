import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '@models/user';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { GetUser, GetUtilisateurFailure, SetUser, UserActionTypes } from '../actions/user.action';
import { UserService } from '@core/services/user.service';

@Injectable()
export class UserEffects {
  logIn$ = createEffect(() =>
    this.actions$.pipe(
      ofType<GetUser>(UserActionTypes.getUser),
      switchMap((result) =>
        this.userService.getUserByEmail(result.payload).pipe(
          map((user: User) => new SetUser(user)),
          catchError(() => of(new GetUtilisateurFailure(result.payload))),
        ),
      ),
    ),
  );

  constructor(private actions$: Actions, private router: Router, private userService: UserService) {}
}
