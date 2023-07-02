import { ChangeDetectorRef, Component, forwardRef, Input, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, FormBuilder, FormGroup, NG_VALUE_ACCESSOR, Validators } from '@angular/forms';
import { GeolocalisationService } from '@core/services/geolocalisation.service';
import { AdresseForMolecule } from '@models/address';
import { ISearch } from '@models/select';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'molecules-adresse',
  templateUrl: './molecules-adresse.component.html',
  styleUrls: ['./molecules-adresse.component.less'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MoleculesAdresseComponent),
      multi: true,
    },
  ],
})
export class MoleculesAdresseComponent implements ControlValueAccessor, OnInit, OnDestroy, OnChanges {
  @Input() adresseComplete: AdresseForMolecule;
  @Input() lectureMode: boolean;

  displayTips = false;
  destroy$: Subject<void> = new Subject<void>();
  villeItems: ISearch[] = [];
  adresseForm: FormGroup;

  ville: string | null = null;
  codePostal: string | null = null;
  voie: string | null = null;
  complementVoie: string | null = null;

  valeurVille: string;

  constructor(private fb: FormBuilder, private geolocalisationService: GeolocalisationService, private changeDetector: ChangeDetectorRef) {}

  ngOnInit() {
    this.remplirInformation();

    this.adresseForm = this.fb.group({
      ville: [{ value: this.ville, disabled: this.lectureMode }, [Validators.required]],
      codePostal: [{ value: this.codePostal, disabled: this.lectureMode }, [Validators.required]],
      street: [{ value: this.voie, disabled: this.lectureMode }, [Validators.required]],
      streetComplement: [{ value: this.complementVoie, disabled: this.lectureMode }],
    });
  }

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  ngOnChanges(_changes: SimpleChanges): void {
    if (this.adresseForm) {
      this.remplirInformation();
      this.adresseForm.controls['ville'].setValue(this.ville);
      this.adresseForm.controls['codePostal'].setValue(this.codePostal);
      this.adresseForm.controls['street'].setValue(this.voie);
      this.adresseForm.controls['streetComplement'].setValue(this.complementVoie);

      if (!this.lectureMode) {
        this.adresseForm.controls['ville'].enable();
        this.adresseForm.controls['codePostal'].enable();
        this.adresseForm.controls['street'].enable();
        this.adresseForm.controls['streetComplement'].enable();
      } else {
        this.adresseForm.controls['ville'].disable();
        this.adresseForm.controls['codePostal'].disable();
        this.adresseForm.controls['street'].disable();
        this.adresseForm.controls['streetComplement'].disable();
      }
    }
  }

  remplirInformation() {
    if (this.adresseComplete && this.adresseComplete.ville) {
      const cpville = this.adresseComplete.ville ? this.adresseComplete.ville.split('$')[1] : null;
      this.codePostal = cpville ? cpville.substring(0, cpville.indexOf('-')) : null;
      this.ville = cpville ? cpville.substring(cpville.indexOf('-') + 1, cpville.length) : null;
      this.voie = this.adresseComplete.libelleVoie;
      this.complementVoie = this.adresseComplete.complementVoie;

      this.valeurVille = this.adresseComplete.ville;
    }
  }

  onSearch(e: Event): void {
    e?.preventDefault();
    const value = (e.target as HTMLInputElement).value;
    if (value && value.length >= 2) {
      this.displayTips = false;
      this.geolocalisationService
        .localisations(value)
        .pipe(takeUntil(this.destroy$))
        .subscribe(
          (villes: ISearch[]) => {
            this.villeItems = villes;
            this.changeDetector.detectChanges();
          },
          (error) => console.log(error),
        );
    } else {
      this.villeItems = [];
      this.changeDetector.detectChanges();
    }
  }

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  propagateChange = (_: any) => {};

  writeValue(value: any): void {
    this.propagateChange(value);
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  public registerOnTouched() {}

  public onChange() {
    const adresseForm = this.adresseForm.value;
    if (this.verificationFormAdresse()) {
      const adresse = new AdresseForMolecule();
      adresse.ville = this.valeurVille;
      adresse.complementVoie = adresseForm.streetComplement;
      adresse.libelleVoie = adresseForm.street;

      this.propagateChange(adresse);
    }
  }

  selectOption(valeur: string) {
    if (valeur && valeur.indexOf('$') > 0) {
      const cpville = valeur.split('$')[1];
      const cp = cpville.substring(0, cpville.indexOf('-'));
      const sville = cpville.substring(cpville.indexOf('-') + 1, cpville.length);
      this.adresseForm.patchValue({ ville: sville, codePostal: cp });
      this.valeurVille = valeur;
      if (this.verificationFormAdresse()) {
        const adresseForm = this.adresseForm.value;
        const adresse = new AdresseForMolecule();
        adresse.ville = this.valeurVille;
        adresse.complementVoie = adresseForm.streetComplement;
        adresse.libelleVoie = adresseForm.street;

        this.propagateChange(adresse);
      }
    }
  }

  verificationFormAdresse() {
    const contactForm = this.adresseForm.value;
    let nook = true;
    if (contactForm.ville === null || contactForm.ville === '') {
      this.adresseForm.controls['ville'].markAsDirty();
      this.adresseForm.controls['ville'].updateValueAndValidity();
      nook = false;
    }
    if (contactForm.codePostal === null || contactForm.codePostal === '') {
      this.adresseForm.controls['codePostal'].markAsDirty();
      this.adresseForm.controls['codePostal'].updateValueAndValidity();
      nook = false;
    }
    if (contactForm.street === null || contactForm.street === '') {
      this.adresseForm.controls['street'].markAsDirty();
      this.adresseForm.controls['street'].updateValueAndValidity();
      nook = false;
    }
    return nook;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
