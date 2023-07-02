import { createSelector } from '@ngrx/store';
import { IAppState } from '../state/app.state';
import { IReferenceDataState } from '../state/referenceData.state';

const selectReferenceData = (state: IAppState) => state.referenceData;

export const getCivilite = createSelector(selectReferenceData, (state: IReferenceDataState) => state.civilities);
