import { ISelect } from '@models/select';

export interface IReferenceDataState {
  civilities: ISelect[];
}

export const initialReferenceDataState: IReferenceDataState = {
  civilities: [],
};
