import { createSelector } from '@ngrx/store';
import { IAppState } from '../state/app.state';
import { IGridsterState } from '../state/gridster.state';

const selectGridster = (state: IAppState) => state.gridster;

export const getGridsterUnlock = createSelector(selectGridster, (state: IGridsterState) => state && state.unlock);
