/* eslint-disable prefer-arrow/prefer-arrow-functions */
import { WidgetListActions, WidgetListActionTypes } from '../actions/page.actions';
import { initialWidgetListState } from '../state/page.state';

export function widgetListReducer(state = initialWidgetListState, action: WidgetListActions) {
  switch (action.type) {
    case WidgetListActionTypes.widgetList:
      return {
        ...state,
        page: action.payload.page,
        widgets: [...action.payload.widgets],
      };
    default:
      return state;
  }
}
