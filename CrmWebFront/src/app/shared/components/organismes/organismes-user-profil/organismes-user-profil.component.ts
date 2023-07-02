import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FormatTelPipe } from '@core/pipes/formatTel.pipe';
import { getCivilite } from '@core/store/selectors/referenceData.selector';
import { getUser } from '@core/store/selectors/utilisateur.selector';
import { IAppState } from '@core/store/state/app.state';
import { AdresseForMolecule } from '@models/address';
import { User } from '@models/user';
import { Store, select } from '@ngrx/store';
import { OrganismesModalChangepasswordComponent } from '@organismes/organismes-modal-changepassword/organismes-modal-changepassword.component';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'organismes-user-profil',
  templateUrl: './organismes-user-profil.component.html',
  styleUrls: ['./organismes-user-profil.component.less'],
})
export class OrganismesUserProfilComponent implements OnInit, OnDestroy {
  userProfilForm: FormGroup;
  civilities$ = this.store.pipe(select(getCivilite));
  user$ = this.store.pipe(select(getUser));
  adresseAutre: AdresseForMolecule;
  lectureMode: boolean = true;
  private destroy$ = new Subject<void>();

  constructor(
    private fb: FormBuilder,
    private modalService: NzModalService,
    private store: Store<IAppState>,
    private formatTelPipe: FormatTelPipe,
  ) {
    this.userProfilForm = this.fb.group({
      civilite: [null],
      firstName: [null],
      lastName: [null],
      adresse: [null],
      mail: [null],
      phone: [null],
      mobile: [null],
    });
  }

  ngOnInit() {
    this.user$.pipe(takeUntil(this.destroy$)).subscribe((res: User) => {
      if (res) {
        this.userProfilForm.controls['civilite'].setValue(res.civilityId);
        this.userProfilForm.controls['firstName'].setValue(res.firstName);
        this.userProfilForm.controls['lastName'].setValue(res.lastName);
        this.userProfilForm.controls['mail'].setValue(res.mail);
        this.userProfilForm.controls['phone'].setValue(this.formatTelPipe.transform(res.phoneNumber));
        this.userProfilForm.controls['mobile'].setValue(this.formatTelPipe.transform(res.mobilePhoneNumber));

        this.adresseAutre = new AdresseForMolecule();
        this.adresseAutre.libelleVoie = res.address.street;
        this.adresseAutre.complementVoie = res.address.streetComplement;
        this.adresseAutre.ville = `V-${res.address.cityId}$${res.address.postalCode}-${res.address.city}`;
      }
    });
  }

  valeurValide() {}

  changePassword() {
    const modalRef = this.modalService.create({
      nzTitle: 'Changement du mot de passe',
      nzContent: OrganismesModalChangepasswordComponent,
      nzClosable: true,
      nzKeyboard: false,
      nzMaskClosable: false,
      nzFooter: null,
      nzWidth: '600px',
      nzComponentParams: {},
    });
    modalRef.afterClose.subscribe(() => {});
  }

  cancel(): void {}

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
