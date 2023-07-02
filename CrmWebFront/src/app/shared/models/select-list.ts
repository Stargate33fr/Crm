import { ISelect } from '@models/select';

export const situationFamiliales: ISelect[] = [
  { valeurAssociee: 'celibataire', libelle: 'Célibataire', id: 1, estVisible: true },
  { valeurAssociee: 'unionLibre', libelle: 'Union Libre', id: 2, estVisible: true },
  { valeurAssociee: 'marie', libelle: 'Marié(e)', id: 3, estVisible: true },
  { valeurAssociee: 'veuf', libelle: 'Veuf(ve)', id: 4, estVisible: true },
  { valeurAssociee: 'divorce', libelle: 'Divorcé(e)', id: 5, estVisible: true },
  { valeurAssociee: 'pacse', libelle: 'Pacsé(e)', id: 6, estVisible: true },
  { valeurAssociee: 'separe', libelle: 'Séparé(e)', id: 7, estVisible: true },
];

export const dureeDEngagement: ISelect[] = [
  { valeurAssociee: '6', libelle: '6 ans', id: 1, estVisible: true },
  { valeurAssociee: '63', libelle: '6+3 ans', id: 2, estVisible: true },
  { valeurAssociee: '66', libelle: '6+6 ans', id: 3, estVisible: true },
  { valeurAssociee: '9', libelle: '9 ans', id: 4, estVisible: true },
  { valeurAssociee: '93', libelle: '9+3 ans', id: 5, estVisible: true },
];

export const fiscalites: ISelect[] = [
  { valeurAssociee: 'pinel', libelle: 'Pinel', id: 1, estVisible: true },
  { valeurAssociee: 'pinel+', libelle: 'Pinel +', id: 2, estVisible: true },
  { valeurAssociee: 'regimeCommun', libelle: 'Régime commun', id: 3, estVisible: true },
  { valeurAssociee: 'lmnp', libelle: 'LMNP', id: 4, estVisible: true },
];

export const zonesGeographiques: ISelect[] = [
  { valeurAssociee: 'ABis', libelle: 'Zone A Bis', id: 1, estVisible: true },
  { valeurAssociee: 'A', libelle: 'Zone A', id: 2, estVisible: true },
  { valeurAssociee: 'B1', libelle: 'Zone B1', id: 3, estVisible: true },
  { valeurAssociee: 'B2', libelle: 'Zone B2', id: 4, estVisible: true },
  { valeurAssociee: 'C', libelle: 'Zone C', id: 5, estVisible: true },
  { valeurAssociee: 'Guadeloupe', libelle: 'Guadeloupe', id: 6, estVisible: true },
  { valeurAssociee: 'Guyane', libelle: 'Guyane', id: 7, estVisible: true },
  { valeurAssociee: 'Martinique ', libelle: 'Martinique', id: 8, estVisible: true },
  { valeurAssociee: 'Reunion ', libelle: 'Réunion', id: 9, estVisible: true },
  { valeurAssociee: 'Mayotte', libelle: 'Mayotte', id: 10, estVisible: true },
  { valeurAssociee: 'SaintBarthelemy', libelle: 'Saint Barthélémy', id: 11, estVisible: true },
  { valeurAssociee: 'SaintMartin', libelle: 'Saint Martin', id: 12, estVisible: true },
  { valeurAssociee: 'SaintPierreEtMiquelon', libelle: 'Saint Pierre et Miquelon', id: 13, estVisible: true },
  { valeurAssociee: 'NouvelleCaledonie', libelle: 'Nouvelle Calédonie', id: 14, estVisible: true },
  { valeurAssociee: 'PolynesieFrancaise', libelle: 'Polynésie Française', id: 15, estVisible: true },
  { valeurAssociee: 'WallisEtFutuna ', libelle: 'Wallis et Futuna', id: 16, estVisible: true },
];
