import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { NzMessageService } from 'ng-zorro-antd/message';
import { map, switchMap } from 'rxjs/operators';
import { MessageActionTypes, MessageFailure, MessageSuccess } from '../actions/message.action';
import { of } from 'rxjs';

@Injectable()
export class MessageEffects {
  messageSuccess = createEffect(
    () =>
      this.actions$.pipe(
        ofType<MessageSuccess>(MessageActionTypes.messageSuccess),
        map((action) => action.payload),
        switchMap((message) => of(this.message.create('success', message))),
      ),
    { dispatch: false },
  );

  messageFailure = createEffect(
    () =>
      this.actions$.pipe(
        ofType<MessageFailure>(MessageActionTypes.messageFailure),
        map((action) => action.payload),
        switchMap((message) => of(this.message.create('error', message))),
      ),
    { dispatch: false },
  );

  constructor(private actions$: Actions, private message: NzMessageService) {}
}
