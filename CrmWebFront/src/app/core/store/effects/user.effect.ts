import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User, UserLight } from '@models/user';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import {
  GetUser,
  GetUsersLight,
  GetUsersLightFailure,
  GetUtilisateurFailure,
  SetUser,
  SetUsersLight,
  UserActionTypes,
} from '../actions/user.action';
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

  users$ = createEffect(() =>
    this.actions$.pipe(
      ofType<GetUsersLight>(UserActionTypes.getUsersLight),
      switchMap((result) =>
        this.userService.getUsersLight().pipe(
          map((user: UserLight[]) => new SetUsersLight(user)),
          catchError(() => of(new GetUsersLightFailure(result.payload))),
        ),
      ),
    ),
  );

  constructor(private actions$: Actions, private router: Router, private userService: UserService) {}
}
