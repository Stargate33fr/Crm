/* eslint-disable prefer-arrow/prefer-arrow-functions */
import { UserActions, UserActionTypes } from '../actions/user.action';
import { initialUserState, IUserState } from '../state/user.state.';

export function userReducer(state = initialUserState, action: UserActions): IUserState {
  switch (action.type) {
    case UserActionTypes.setIdentifiantUser:
      return {
        ...state,
        identifiant: action.payload,
      };
    case UserActionTypes.setUser:
      return {
        ...state,
        user: action.payload.serialize(),
      };
    case UserActionTypes.setUsersLight:
      return {
        ...state,
        usersLight: action.payload,
      };
    case UserActionTypes.userSuccess:
      return {
        ...state,
        user: action.payload.serialize(),
      };
    default:
      return state;
  }
}
