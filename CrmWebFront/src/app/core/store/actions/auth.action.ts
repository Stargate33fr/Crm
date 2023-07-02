import { Action } from '@ngrx/store';
import { Token } from 'src/app/shared/models/token';

export enum AuthActionType {
  changePasswordConnected = '[Auth] ChangePassword Connected',
  changePasswordSuccess = '[Auth] ChangePassword success',
  changePasswordFailure = '[Auth] ChangePassword failure',
  login = '[Auth] Login',
  loginSuccess = '[Auth] Login Success',
  loginFailure = '[Auth] Login Failure',
  logout = '[Auth] Logout',
  expiredSession = '[Auth] Session Expired',
  reLogin = '[Auth] Re-Login',
  reLoginSuccess = '[Auth] Re-Login Success',
}

export class LogIn implements Action {
  readonly type = AuthActionType.login;
  constructor(public payload: { identifiant: string; password: string }) {}
}

export class ReLogin implements Action {
  readonly type = AuthActionType.reLogin;
  constructor() {}
}

export class ReLoginSuccess implements Action {
  readonly type = AuthActionType.reLoginSuccess;
  constructor(public payload: Token) {}
}

export class LogInSuccess implements Action {
  public readonly type = AuthActionType.loginSuccess;
  constructor(public payload: Token) {}
}

export class LogInFailure implements Action {
  public readonly type = AuthActionType.loginFailure;
  constructor(public payload: string) {}
}

export class Logout implements Action {
  public readonly type = AuthActionType.logout;
  constructor() {}
}

export class ExpiredSession implements Action {
  public readonly type = AuthActionType.expiredSession;
  constructor() {}
}

export class ChangePassword implements Action {
  readonly type = AuthActionType.changePasswordConnected;
  constructor(public payload: { email: string; password: string; passwordActuel: string }) {}
}

export class ChangePasswordSucess implements Action {
  readonly type = AuthActionType.changePasswordSuccess;
  constructor(public payload: { success: boolean }) {}
}

export class ChangePasswordFailure implements Action {
  readonly type = AuthActionType.changePasswordFailure;
  constructor(public payload: string) {}
}

export type AuthAction =
  | LogIn
  | LogInSuccess
  | LogInFailure
  | Logout
  | ExpiredSession
  | ReLogin
  | ReLoginSuccess
  | ChangePassword
  | ChangePasswordSucess
  | ChangePasswordFailure;
