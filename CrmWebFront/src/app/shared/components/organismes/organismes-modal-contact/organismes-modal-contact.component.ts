import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FormatTelPipe } from '@core/pipes/formatTel.pipe';
import { ContactService } from '@core/services/contact.service';
import { IAppState } from '@core/store/state/app.state';
import { AdresseForMolecule } from '@models/address';
import { IContact, UpdateContact } from '@models/contact';
import { ISelect } from '@models/select';
import { Store } from '@ngrx/store';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { Observable, Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-organismes-modal-contact',
  templateUrl: './organismes-modal-contact.component.html',
  styleUrls: ['./organismes-modal-contact.component.less'],
})
export class OrganismesModalContactComponent implements OnInit, OnDestroy {
  @ViewChild('inputElementPortable') inputElementPortable: ElementRef;
  @ViewChild('inputElementTelephone') inputElementTelephone: ElementRef;

  contact: IContact;
  contactForm: FormGroup;
  users$: Observable<ISelect[]>;

  adresseAutre: AdresseForMolecule;
  lectureMode: boolean = true;
  valuePortable: string | null = null;
  valueTelephone: string | null = null;
  destroy$ = new Subject<void>();
  constructor(
    private contactService: ContactService,

    private modal: NzModalRef,
    private fb: FormBuilder,
    private store: Store<IAppState>,
    private formatTelPipe: FormatTelPipe,
    private message: NzMessageService,
  ) {}

  ngOnInit() {
    this.contactForm = this.fb.group({
      firstName: [this.contact.firstName],
      lastName: [this.contact.lastName],
      address: [null],
      mail: [this.contact.mail],
      phone: [this.formatTelPipe.transform(this.contact.phoneNumber)],
      mobile: [this.formatTelPipe.transform(this.contact.mobilePhoneNumber)],
      idConseiller: [this.contact.conseillerId],
    });

    this.adresseAutre = new AdresseForMolecule();
    this.adresseAutre.libelleVoie = this.contact.address.street;
    this.adresseAutre.complementVoie = this.contact.address.streetComplement;
    this.adresseAutre.ville = `V-${this.contact.address.cityId}$${this.contact.address.postalCode}-${this.contact.address.city}`;
  }

  valeurValide() {
    const contactFormValue = this.contactForm.value;

    this.valuePortable = new FormatTelPipe().transform(contactFormValue.mobile);
    this.contactForm.controls['mobile'].setValue(this.valuePortable);

    this.valueTelephone = new FormatTelPipe().transform(contactFormValue.phone);
    this.contactForm.controls['phone'].setValue(this.valueTelephone);
  }

  save() {
    const contactFormValue = this.contactForm.value;

    const data = new UpdateContact();
    data.id = this.contact.id;
    data.firstName = contactFormValue.firstName;
    data.lastName = contactFormValue.lastName;
    data.phoneNumber = contactFormValue.phone;
    data.mobilePhoneNumber = contactFormValue.mobile;
    data.idConseiller = contactFormValue.idConseiller;

    if (contactFormValue.address) {
      data.street = contactFormValue.address.libelleVoie;
      data.complementStreet = contactFormValue.address.complementVoie;
      data.cityId = +contactFormValue.address.ville.split('$')[0].split('-')[1];
    } else {
      data.street = this.contact.address.street;
      data.complementStreet = this.contact.address.streetComplement;
      data.cityId = this.contact.address.cityId;
    }

    this.contactService
      .updateContacts(data)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.modal.close(true);
        },
        error: () => {
          this.message.create('error', `[CONTACT] une erreur s'est produit lors de la mise à jour du contact ${this.contact.id}`);
        },
      });
  }

  destroyModal(): void {
    this.modal.destroy();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
