import { Address, IAddress } from './address';

export interface IUser {
  id: number;
  civilityId: number;
  addressId: number;
  lastName: string;
  firstName: string;
  phoneNumber: string;
  mobilePhoneNumber: string;
  mail: string;
  password: string;
  actif: boolean;
  lock: boolean;
  address: IAddress;
}

export interface IUserLight {
  id: number;
  lastName: string;
  firstName: string;
}

export class User implements IUser {
  id: number;
  civilityId: number;
  addressId: number;
  lastName: string;
  firstName: string;
  phoneNumber: string;
  mobilePhoneNumber: string;
  mail: string;
  password: string;
  actif: boolean;
  lock: boolean;
  address: Address;

  deserialize(input: IUser): User {
    if (input) {
      const user = new User();
      user.id = input.id;
      user.firstName = input.firstName;
      user.lastName = input.lastName;
      user.mail = input.mail;
      user.password = input.password;
      user.actif = input.actif;
      user.lock = input.lock;
      user.civilityId = input.civilityId;
      user.phoneNumber = input.phoneNumber;
      user.mobilePhoneNumber = input.mobilePhoneNumber;
      user.addressId = input.addressId;
      user.address = new Address().deserialize(input.address);

      return user;
    }
    return null as any;
  }

  serialize(): IUser {
    return {
      id: this.id,
      civilityId: this.civilityId,
      addressId: this.addressId,
      lastName: this.lastName,
      firstName: this.firstName,
      phoneNumber: this.phoneNumber,
      mobilePhoneNumber: this.mobilePhoneNumber,
      mail: this.mail,
      password: this.password,
      actif: this.actif,
      lock: this.lock,
      address: this.address.serialize(),
    };
  }
}

export interface IUser {
  id: number;
  civilityId: number;
  addressId: number;
  lastName: string;
  firstName: string;
  phoneNumber: string;
  mobilePhoneNumber: string;
  mail: string;
  password: string;
  actif: boolean;
  lock: boolean;
  address: IAddress;
}

export class UserLight implements IUserLight {
  id: number;
  lastName: string;
  firstName: string;

  deserialize(input: IUserLight): UserLight {
    if (input) {
      const user = new UserLight();
      user.id = input.id;
      user.firstName = input.firstName;
      user.lastName = input.lastName;
      return user;
    }
    return null as any;
  }

  deserializeList(input: IUserLight[]): UserLight[] {
    return input.map((x) => this.deserialize(x));
  }

  serialize(): IUserLight {
    return {
      id: this.id,
      lastName: this.lastName,
      firstName: this.firstName,
    };
  }
}
