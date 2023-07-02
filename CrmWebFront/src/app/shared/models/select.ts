export enum ChoixOuiNon {
  oui = 1,
  non = 0,
}

export interface ISearch {
  key: string;
  value: string;
}

export class Search implements ISearch {
  key: string;
  value: string;
}

export interface ISelect {
  id: number;
  libelle: string;
  sousListe?: ISelect[];
  estVisible: boolean;
  valeurAssociee: string;
}

export class Select implements ISelect {
  id: number;
  libelle: string;
  sousListe?: ISelect[] = [];
  estVisible: boolean;
  valeurAssociee: string;

  deserialize(input: ISelect): Select {
    if (input) {
      const selection = new Select();
      selection.id = input.id;
      selection.estVisible = input.estVisible;
      selection.libelle = input.libelle;
      selection.sousListe = input.sousListe ? new Select().deserializeList(input.sousListe) : [];
      selection.valeurAssociee = input.valeurAssociee;

      return selection;
    }
    return null as any;
  }

  deserializeList(input: ISelect[]): Select[] {
    if (input) {
      return input.map((x) => this.deserialize(x));
    }
    return null as any;
  }
  serialize(): ISelect {
    return {
      id: this.id,
      libelle: this.libelle,
      sousListe: this.sousListe,
      valeurAssociee: this.valeurAssociee,
      estVisible: this.estVisible,
    };
  }
}
