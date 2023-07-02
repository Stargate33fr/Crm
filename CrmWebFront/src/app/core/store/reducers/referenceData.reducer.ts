/* eslint-disable prefer-arrow/prefer-arrow-functions */
import { ReferenceDataActions, ReferenceDataActionTypes } from '../actions/referenceDate';
import { initialReferenceDataState, IReferenceDataState } from '../state/referenceData.state';

export function referenceDataReducer(state = initialReferenceDataState, action: ReferenceDataActions): IReferenceDataState {
  switch (action.type) {
    case ReferenceDataActionTypes.setCivilities:
      return {
        ...state,
        civilities: action.payload,
      };

    default:
      return state;
  }
}
