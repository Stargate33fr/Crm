import { IAppState } from '@core/store/state/app.state';
import { createSelector } from '@ngrx/store';
import { IWidgetListState } from '../state/page.state';

const selectWidgetList = (state: IAppState) => state.widgetList;

export const getWidgetList = createSelector(selectWidgetList, (state: IWidgetListState) => state && state.page && state.widgets);
