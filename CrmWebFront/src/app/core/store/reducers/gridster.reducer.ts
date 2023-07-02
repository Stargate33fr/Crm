/* eslint-disable prefer-arrow/prefer-arrow-functions */
import { GridsterActions, GridsterActionsTypes } from '../actions/gridster.actions';
import { IGridsterState, initialGridsterState } from '../state/gridster.state';

export function gridsterReducer(state = initialGridsterState, action: GridsterActions): IGridsterState {
  switch (action.type) {
    case GridsterActionsTypes.unlock:
      return {
        ...state,
        unlock: true,
      };
    case GridsterActionsTypes.lock:
      return {
        ...state,
        unlock: false,
      };
    case GridsterActionsTypes.cancel:
      return {
        ...state,
        unlock: false,
      };
    case GridsterActionsTypes.reset:
      return {
        ...state,
        unlock: false,
      };
    default:
      return state;
  }
}
