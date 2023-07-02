import { ResponseAPIDto } from '../dto/response-api';
import { IAddress, Address } from './address';
import { IDeserializable } from './deserializable.interface';

export interface IContact {
  id: number;
  firstName: string;
  lastName: string;
  address: IAddress;
  conseillerId: number;
  firstNameConseiller: string;
  lastNameConseiller: string;
  mail: string;
  phoneNumber: string;
  mobilePhoneNumber: string;
}

export class Contact implements IContact {
  id: number;
  firstName: string;
  lastName: string;
  address: Address;
  conseillerId: number;
  firstNameConseiller: string;
  lastNameConseiller: string;
  mail: string;
  phoneNumber: string;
  mobilePhoneNumber: string;

  deserialize(input: IContact): Contact {
    if (input) {
      const contact = new Contact();
      contact.id = input.id;
      contact.firstName = input.firstName;
      contact.lastName = input.lastName;
      contact.address = new Address().deserialize(input.address);
      contact.phoneNumber = input.phoneNumber;
      contact.mobilePhoneNumber = input.mobilePhoneNumber;
      contact.mail = input.mail;
      contact.conseillerId = input.conseillerId;
      contact.firstNameConseiller = input.firstNameConseiller;
      contact.lastNameConseiller = input.lastNameConseiller;
      return contact;
    }
    return null as any;
  }

  deserializeList(input: IContact[]): Contact[] {
    return input.map((x) => this.deserialize(x));
  }

  serialize(): IContact {
    return {
      id: this.id,
      lastName: this.lastName,
      firstName: this.firstName,
      phoneNumber: this.phoneNumber,
      mobilePhoneNumber: this.mobilePhoneNumber,
      mail: this.mail,
      address: this.address.serialize(),
      conseillerId: this.conseillerId,
      firstNameConseiller: this.firstNameConseiller,
      lastNameConseiller: this.lastNameConseiller,
    };
  }
}

export class Contacts implements IDeserializable<Contacts> {
  contenu: Contact[];
  total: number;

  deserialize(input: ResponseAPIDto<IContact[]>): Contacts {
    if (input) {
      const contacts = new Contacts();
      contacts.contenu = input.contenu.map((item) => new Contact().deserialize(item));
      contacts.total = input.total;
      return contacts;
    }

    return null as any;
  }
}

export class ContactFilter {
  mail: string;
  firstName: string;
  lastName: string;
  conseillerId: number;
  tri: Tri;
  pagination: Pagination;
}

export class Tri {
  champ?: string;
  ascendant?: boolean;
}

export class Pagination {
  limite: number;
  index: number;
}

export class UpdateContact {
  id: number;
  firstName: string;
  lastName: string;
  street: string;
  complementStreet: string;
  cityId: number;
  phoneNumber: string;
  mobilePhoneNumber: string;
  idConseiller: number;
}
