import { ActionReducerMap } from '@ngrx/store';
import { IAppState } from '../state/app.state';
import { authReducer } from './auth.reducer';
import { contextReducer } from './context.reducer';
import { userReducer } from './user.reducer';
import { referenceDataReducer } from './referenceData.reducer';

export const appReducers: ActionReducerMap<IAppState, any> = {
  auth: authReducer,
  context: contextReducer,
  user: userReducer,
  referenceData: referenceDataReducer,
};
