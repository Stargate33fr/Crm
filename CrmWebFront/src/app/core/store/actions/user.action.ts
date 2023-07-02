import { User } from '@models/user';
import { Action } from '@ngrx/store';

// eslint-disable-next-line no-shadow
export enum UserActionTypes {
  getUser = '[Utilisateur] Get User',
  setUser = '[Utilisateur] Set User',
  userFailure = '[Utilisateur] User Failure',
  userSuccess = '[Utilisateur] User Success',
  setIdentifiantUser = '[Utilisateur] User Idenfiant',
}

export class GetUser implements Action {
  readonly type = UserActionTypes.getUser;
  constructor(public payload: string) {}
}

export class SetIdentifiantUser implements Action {
  public readonly type = UserActionTypes.setIdentifiantUser;
  constructor(public payload: string) {}
}

export class SetUser implements Action {
  public readonly type = UserActionTypes.setUser;
  constructor(public payload: User) {}
}

export class GetUtilisateurFailure implements Action {
  public readonly type = UserActionTypes.userFailure;
  constructor(public payload: string) {}
}

export class GetUtilisateurSuccess implements Action {
  public readonly type = UserActionTypes.userSuccess;
  constructor(public payload: User) {}
}

export type UserActions = GetUser | SetUser | GetUtilisateurFailure | GetUtilisateurSuccess | SetIdentifiantUser;
