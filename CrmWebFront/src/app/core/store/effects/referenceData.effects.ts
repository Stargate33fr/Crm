import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { GetCivilitiesFailure, SetCivilities } from '../actions/referenceDate';
import { ReferenceDataService } from '@core/services/referenceData.service';
import { IAppState } from '../state/app.state';
import { Store } from '@ngrx/store';
import { AuthActionType, LogInSuccess } from '../actions/auth.action';
import { ISelect } from '@models/select';

@Injectable()
export class ReferenceDataEffects {
  civilite$ = createEffect(() =>
    this.actions$.pipe(
      ofType<LogInSuccess>(AuthActionType.loginSuccess, AuthActionType.reLoginSuccess),
      switchMap(() =>
        this.referenceDataService.getCivilities().pipe(
          map((civilities: ISelect[]) => new SetCivilities(civilities)),
          catchError(() => of(new GetCivilitiesFailure("Une erreur s'est produit lors de la récupération des civilités"))),
        ),
      ),
    ),
  );

  constructor(private actions$: Actions, private store: Store<IAppState>, private referenceDataService: ReferenceDataService) {}
}
