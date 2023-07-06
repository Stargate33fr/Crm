import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { RoutingKeys } from '@core/rounting/routing-keys';
import { ContactService } from '@core/services/contact.service';
import { UserService } from '@core/services/user.service';
import { GetUsersLight } from '@core/store/actions/user.action';
import { getUser, getUsersLight } from '@core/store/selectors/utilisateur.selector';
import { IAppState } from '@core/store/state/app.state';
import { ContactFilter, IContact, Pagination, Tri } from '@models/contact';
import { ISelect, Select } from '@models/select';

import { User, UserLight } from '@models/user';
import { Store, select } from '@ngrx/store';
import { OrganismesModalContactComponent } from '@organismes/organismes-modal-contact/organismes-modal-contact.component';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzTableQueryParams } from 'ng-zorro-antd/table';

import { Observable, Subject, combineLatest, of, switchMap, takeUntil, tap } from 'rxjs';

@Component({
  selector: 'templates-dashboard',
  templateUrl: './templates-dashboard.component.html',
  styleUrls: ['./templates-dashboard.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TemplatesDashboardComponent implements OnInit, OnDestroy {
  theme: string;
  datejour: Date;
  loading = true;
  total = 12;
  pageSize = 10;
  pageIndex = 1;
  userLightForm: FormGroup;
  listOfContact: IContact[] = [];
  users: Select[] = [];
  user$: Observable<User> = this.store.pipe(select(getUser));
  usersLight$: Observable<UserLight[]> = this.store.pipe(select(getUsersLight));
  usersLightForSelect$: Observable<ISelect[]>;
  routingKeys = RoutingKeys;
  idConseiller: number = -1;
  sortDirections: ['ascend', 'descend'];

  private destroy$ = new Subject<void>();

  constructor(
    private store: Store<IAppState>,
    private contactService: ContactService,
    private modalService: NzModalService,
    private userService: UserService,
    private ref: ChangeDetectorRef,
    private fb: FormBuilder,
  ) {}

  ngOnInit() {
    this.userLightForm = this.fb.group({
      idConseiller: [null],
    });
    this.store.dispatch(new GetUsersLight('all'));
    this.loadDataFromServer(this.idConseiller, this.pageIndex, this.pageSize, null, null, []);
  }

  valeurUserLightChange(id: number) {
    this.idConseiller = id;
    this.loadDataFromServer(this.idConseiller, this.pageIndex, this.pageSize, null, null, []);
  }

  loadDataFromServer(
    idConseiller: number,
    pageIndex: number,
    pageSize: number,
    sortField: string | null,
    sortOrder: string | null,
    filter: Array<{ key: string; value: string[] }>,
  ) {
    const contactFilter = new ContactFilter();

    combineLatest([this.user$, this.usersLight$])
      .pipe(
        takeUntil(this.destroy$),
        tap((resultat) => {
          if (resultat[0]) {
            contactFilter.conseillerId = resultat[0].id;
            if (this.idConseiller === -1) {
              this.idConseiller = resultat[0].id;
            }

            contactFilter.tri = new Tri();
            contactFilter.conseillerId = this.idConseiller;
            contactFilter.tri.champ = sortField ? sortField : 'id';
            contactFilter.tri.ascendant = sortOrder && sortOrder === 'ascend' ? true : false;
            contactFilter.pagination = new Pagination();
            contactFilter.pagination.index = pageIndex - 1;
            contactFilter.pagination.limite = pageSize;
          }
          if (resultat[1]) {
            if (resultat[1] && resultat[1].length > 0) {
              resultat[1].map((u) => {
                const userSelect = new Select();
                userSelect.id = u.id;
                userSelect.libelle = `${u.firstName} ${u.lastName}`;
                this.users = [...this.users, userSelect];
              });
              this.usersLightForSelect$ = of(this.users);
            }
          }
        }),
        switchMap(() => this.contactService.getContacts(contactFilter)),
        tap((contacts) => {
          if (contacts) {
            this.listOfContact = contacts.contenu;
            this.total = contacts.total;
            this.ref.markForCheck();
            this.loading = false;
          }
        }),
      )
      .subscribe();
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const { pageSize, pageIndex, sort, filter } = params;
    const currentSort = sort.find((item) => item.value !== null);
    const sortField = (currentSort && currentSort.key) || null;
    const sortOrder = (currentSort && currentSort.value) || null;
    this.loadDataFromServer(this.idConseiller, pageIndex, pageSize, sortField, sortOrder, filter);
  }

  showModalContact(contact: IContact) {
    const modalRef = this.modalService.create({
      nzTitle: '',
      nzContent: OrganismesModalContactComponent,
      nzFooter: null,
      nzWidth: '800px',
      nzComponentParams: {
        contact,
        users$: this.usersLightForSelect$,
      },
    });

    modalRef.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadDataFromServer(this.idConseiller, this.pageIndex, this.pageSize, null, null, []);
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
    this.ref.detach();
  }
}
