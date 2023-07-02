import { Civility } from '@models/civility';
import { ISelect } from '@models/select';
import { Action } from '@ngrx/store';

// eslint-disable-next-line no-shadow
export enum ReferenceDataActionTypes {
  getCivilities = '[Civilities] Get Civilities',
  setCivilities = '[Civilities] Set Civilities',
  civilitiesFailure = '[Civilities] Civilities Failure',
  civilitiesSuccess = '[Civilities] Civilities Success',
}

export class GetCivilities implements Action {
  readonly type = ReferenceDataActionTypes.getCivilities;
  constructor(public payload: string) {}
}

export class GetCivilitiesFailure implements Action {
  public readonly type = ReferenceDataActionTypes.civilitiesFailure;
  constructor(public payload: string) {}
}

export class GetCivilitiesSuccess implements Action {
  public readonly type = ReferenceDataActionTypes.civilitiesSuccess;
  constructor(public payload: Civility[]) {}
}

export class SetCivilities implements Action {
  public readonly type = ReferenceDataActionTypes.setCivilities;
  constructor(public payload: ISelect[]) {}
}

export type ReferenceDataActions = GetCivilities | GetCivilitiesFailure | GetCivilitiesSuccess | SetCivilities;
