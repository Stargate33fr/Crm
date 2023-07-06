import { User, UserLight } from '@models/user';
import { Action } from '@ngrx/store';

// eslint-disable-next-line no-shadow

export enum UserActionTypes {
  getUser = '[Utilisateur] Get User',
  setUser = '[Utilisateur] Set User',
  userFailure = '[Utilisateur] User Failure',
  userSuccess = '[Utilisateur] User Success',
  setIdentifiantUser = '[Utilisateur] User Idenfiant',
  getUsersLight = '[Utilisateur] Get Users',
  setUsersLight = '[Utilisateur] Set Users light',
  usersLightFailure = '[Utilisateur] Users light Failure',
}

export class GetUser implements Action {
  readonly type = UserActionTypes.getUser;
  constructor(public payload: string) {}
}

export class GetUsersLight implements Action {
  readonly type = UserActionTypes.getUsersLight;
  constructor(public payload: string) {}
}

export class SetIdentifiantUser implements Action {
  public readonly type = UserActionTypes.setIdentifiantUser;
  constructor(public payload: string) {}
}
export class SetUsersLight implements Action {
  public readonly type = UserActionTypes.setUsersLight;
  constructor(public payload: UserLight[]) {}
}

export class SetUsers implements Action {
  public readonly type = UserActionTypes.setUser;
  constructor(public payload: User[]) {}
}

export class SetUser implements Action {
  public readonly type = UserActionTypes.setUser;
  constructor(public payload: User) {}
}

export class GetUsersLightFailure implements Action {
  public readonly type = UserActionTypes.userFailure;
  constructor(public payload: string) {}
}

export class GetUtilisateurFailure implements Action {
  public readonly type = UserActionTypes.userFailure;
  constructor(public payload: string) {}
}

export class GetUtilisateurSuccess implements Action {
  public readonly type = UserActionTypes.userSuccess;
  constructor(public payload: User) {}
}

export type UserActions =
  | GetUsersLight
  | SetUsersLight
  | GetUsersLightFailure
  | GetUser
  | SetUser
  | GetUtilisateurFailure
  | GetUtilisateurSuccess
  | SetIdentifiantUser;
