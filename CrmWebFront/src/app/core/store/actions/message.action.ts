import { Action } from '@ngrx/store';

// eslint-disable-next-line no-shadow
export enum MessageActionTypes {
  messageSuccess = '[Message] Message Success',
  messageFailure = '[Message] Message Failure',
}

export class MessageSuccess implements Action {
  public readonly type = MessageActionTypes.messageSuccess;
  constructor(public payload: string) {}
}

export class MessageFailure implements Action {
  public readonly type = MessageActionTypes.messageFailure;
  constructor(public payload: string) {}
}

export type MessageActions = MessageSuccess | MessageFailure;
