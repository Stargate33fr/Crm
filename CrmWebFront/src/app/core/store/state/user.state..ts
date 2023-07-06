import { IUser, IUserLight } from '@models/user';

export interface IUserState {
  user: IUser;
  identifiant: string;
  usersLight: IUserLight[];
}

export const initialUserState: IUserState = {
  user: null as any,
  usersLight: null as any,
  identifiant: null as any,
};
