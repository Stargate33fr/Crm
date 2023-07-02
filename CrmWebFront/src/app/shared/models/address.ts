export interface IAddress {
  street: string;
  streetComplement: string;
  postalCode: string;
  city: string;
  department: string;
  region: string;
  country: string;
  codeDepartement: string;
  cityId: number;
  departmentId: number;
  regionId: number;
  countryId: number;
}

export class Address implements IAddress {
  street: string;
  streetComplement: string;
  postalCode: string;
  city: string;
  department: string;
  region: string;
  country: string;
  codeDepartement: string;
  cityId: number;
  departmentId: number;
  regionId: number;
  countryId: number;

  deserialize(input: IAddress): Address {
    if (input) {
      const address = new Address();
      address.street = input.street;
      address.streetComplement = input.streetComplement;
      address.postalCode = input.postalCode;
      address.city = input.city;
      address.department = input.department;
      address.region = input.region;
      address.country = input.country;
      address.codeDepartement = input.codeDepartement;
      address.cityId = input.cityId;
      address.departmentId = input.departmentId;
      address.regionId = input.regionId;
      address.countryId = input.countryId;

      return address;
    }
    return null as any;
  }

  serialize(): IAddress {
    return {
      street: this.street,
      streetComplement: this.streetComplement,
      postalCode: this.postalCode,
      city: this.city,
      department: this.department,
      region: this.region,
      country: this.country,
      codeDepartement: this.codeDepartement,
      cityId: this.cityId,
      departmentId: this.departmentId,
      regionId: this.regionId,
      countryId: this.countryId,
    };
  }
}

export interface IAdresseForMolecule {
  libelleVoie: string;
  complementVoie: string;
  ville: string;
  adresseSecondaire: boolean;
}

export class AdresseForMolecule implements IAdresseForMolecule {
  libelleVoie: string;
  complementVoie: string;
  ville: string;
  adresseSecondaire: boolean;
}
