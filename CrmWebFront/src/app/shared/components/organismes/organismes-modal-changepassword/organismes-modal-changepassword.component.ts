import { ChangeDetectionStrategy, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChangePassword, Logout } from '@core/store/actions/auth.action';
import { getUser } from '@core/store/selectors/utilisateur.selector';
import { IAppState } from '@core/store/state/app.state';
import { User } from '@models/user';
import { select, Store } from '@ngrx/store';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { Observable, Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'organismes-modal-changepassword',
  templateUrl: './organismes-modal-changepassword.component.html',
  styleUrls: ['./organismes-modal-changepassword.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class OrganismesModalChangepasswordComponent implements OnInit, OnDestroy {
  reinitPasswordForm: FormGroup;
  user$: Observable<User> = this.store.pipe(select(getUser));
  idCollaborateur: number;
  destroy$: Subject<void> = new Subject<void>();
  userEnCours: User;
  isLoading: false;
  constructor(
    private fb: FormBuilder,
    private store: Store<IAppState>,
    private modal: NzModalRef,
    private nzMessageService: NzMessageService,
  ) {}

  ngOnInit() {
    this.reinitPasswordForm = this.fb.group({
      email: [{ value: null, disabled: true }, [Validators.email, Validators.required]],
      passwordActuel: [null, Validators.required],
      password1: [null, Validators.required],
      password2: [null, Validators.required],
    });

    this.user$
      .pipe(
        map((user) => {
          this.userEnCours = user;

          this.reinitPasswordForm.controls['email'].setValue(user.mail);
        }),
        takeUntil(this.destroy$),
      )
      .subscribe();
  }

  valid() {
    const formValue = this.reinitPasswordForm.value;
    if (formValue.password1 !== formValue.password1) {
      this.nzMessageService.error("le mot de passe que vous avez indiqué n'est pas correct");
    } else {
      if (formValue.password2 === formValue.passwordActuel) {
        this.nzMessageService.info('Aucun changement de mot de passe detecté');
        this.close(false);
      } else {
        this.store.dispatch(
          new ChangePassword({
            email: this.userEnCours.mail,
            password: formValue.password2,
            passwordActuel: formValue.passwordActuel,
          }),
        );
        this.nzMessageService.info('Changement de mot de passe effectué, veuillez-vous reconnecter');
        this.store.dispatch(new Logout());
        this.close(true);
      }
    }
  }

  close(statut: boolean) {
    this.modal.close(statut);
    this.destroyModal();
  }

  destroyModal(): void {
    this.modal.destroy();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
