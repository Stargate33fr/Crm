import { IDeserializable } from './deserializable.interface';

export interface ICivility {
  shortName: string;
  longName: string;
  id: number;
}

export class Civility implements ICivility, IDeserializable<ICivility> {
  shortName!: string;
  longName!: string;
  id!: number;

  deserialize(input: ICivility): Civility {
    if (input) {
      const civility = new Civility();
      civility.id = input.id;
      civility.shortName = input.shortName;
      civility.longName = input.longName;

      return civility;
    }
    return null as any;
  }

  deserializeList(input: ICivility[]): Civility[] {
    return input.map((x) => this.deserialize(x));
  }

  serialize(): ICivility {
    return {
      id: this.id,
      shortName: this.shortName,
      longName: this.longName,
    };
  }
}
