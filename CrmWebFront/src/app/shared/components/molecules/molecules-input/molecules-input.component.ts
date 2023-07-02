import { ChangeDetectorRef, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { NzAutocompleteComponent } from 'ng-zorro-antd/auto-complete';
import { Subject } from 'rxjs';

@Component({
  selector: 'molecules-input',
  templateUrl: './molecules-input.component.html',
  styleUrls: ['./molecules-input.component.less'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MoleculesInputComponent),
      multi: true,
    },
  ],
})
export class MoleculesInputComponent implements OnInit, OnDestroy {
  @Input() id: string;
  @Input() placeholder: string;
  @Input() uniteDeMesure: string;
  @Input() longueur: string;
  @Input() disabled: boolean = false;
  @Input() autoComplete: NzAutocompleteComponent;
  @Input() readonly: boolean;

  @ViewChild('inputElement', { static: false }) inputElement: ElementRef;

  valeur = '';
  audessusvisible = false;

  private destroy$: Subject<void> = new Subject<void>();

  constructor(private ref: ChangeDetectorRef) {}

  ngOnInit() {}

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  propagateChange = (_: any) => {};

  writeValue(valeur: any): void {
    if (valeur) {
      if (valeur && valeur.target && valeur.target.value) {
        if (typeof valeur === 'number') {
          this.propagateChange(valeur);
          this.inputElement.nativeElement.value = valeur;
          this.ref.markForCheck();
        } else {
          this.propagateChange(valeur.target.value);
          this.inputElement.nativeElement.value = valeur.target.value;
          this.ref.markForCheck();
        }

        this.audessusvisible = true;
      } else {
        if (typeof valeur === 'string') {
          this.valeur = valeur;
        } else {
          this.audessusvisible = false;
          this.inputElement.nativeElement.value = null;
        }
      }
    } else {
      if (!valeur) {
        this.valeur = '';
        this.propagateChange(this.valeur);
        if (this.inputElement) {
          this.inputElement.nativeElement.value = this.valeur;
        }
      } else {
        this.propagateChange(valeur.target.value);
      }
    }
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  focus() {
    this.audessusvisible = true;
  }

  public registerOnTouched() {}

  onChange(value: string): void {
    this.updateValue(value);
  }

  updateValue(value: string): void {
    if (value || value === '') {
      this.valeur = value;
      this.propagateChange(this.valeur);
    }
    this.inputElement.nativeElement.value = this.valeur;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
