import { IAuthState, initialAuthState } from './auth.state';
import { IContextState, initialContextState } from './context.state';
import { IReferenceDataState, initialReferenceDataState } from './referenceData.state';
import { initialUserState, IUserState } from './user.state.';

export interface IAppState {
  auth: IAuthState;
  context: IContextState;
  user: IUserState;
  referenceData: IReferenceDataState;
}

export const initialAppState: IAppState = {
  auth: initialAuthState,
  context: initialContextState,
  user: initialUserState,
  referenceData: initialReferenceDataState,
};

export const getInitialState = () => {
  return initialAppState;
};
