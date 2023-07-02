import { IUser } from '@models/user';

export interface IUserState {
  user: IUser;
  identifiant: string;
}

export const initialUserState: IUserState = {
  user: null as any,
  identifiant: null as any,
};
