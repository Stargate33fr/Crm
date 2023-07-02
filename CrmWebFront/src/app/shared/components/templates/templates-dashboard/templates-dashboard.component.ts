import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';

import { RoutingKeys } from '@core/rounting/routing-keys';
import { ContactService } from '@core/services/contact.service';
import { UserService } from '@core/services/user.service';
import { getUser } from '@core/store/selectors/utilisateur.selector';
import { IAppState } from '@core/store/state/app.state';
import { ContactFilter, IContact, Pagination, Tri } from '@models/contact';
import { Select } from '@models/select';

import { User } from '@models/user';
import { Store, select } from '@ngrx/store';
import { OrganismesModalContactComponent } from '@organismes/organismes-modal-contact/organismes-modal-contact.component';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzTableQueryParams } from 'ng-zorro-antd/table';

import { Observable, Subject, of, switchMap, takeUntil, tap } from 'rxjs';

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
  listOfContact: IContact[] = [];
  users: Select[] = [];
  user$: Observable<User> = this.store.pipe(select(getUser));
  routingKeys = RoutingKeys;
  sortDirections: ['ascend', 'descend'];

  private destroy$ = new Subject<void>();

  constructor(
    private store: Store<IAppState>,
    private contactService: ContactService,
    private modalService: NzModalService,
    private userService: UserService,
    private ref: ChangeDetectorRef,
  ) {}

  ngOnInit() {
    this.loadDataFromServer(this.pageIndex, this.pageSize, null, null, []);
    this.userService
      .getUsersLight()
      .pipe(takeUntil(this.destroy$))
      .subscribe((res) => {
        res.forEach((u) => {
          const userSelect = new Select();
          userSelect.id = u.id;
          userSelect.libelle = `${u.firstName} ${u.lastName}`;
          this.users = [...this.users, userSelect];
        });
      });
  }

  loadDataFromServer(
    pageIndex: number,
    pageSize: number,
    sortField: string | null,
    sortOrder: string | null,
    filter: Array<{ key: string; value: string[] }>,
  ) {
    const contactFilter = new ContactFilter();

    this.user$
      .pipe(
        takeUntil(this.destroy$),
        tap((user) => {
          if (user) {
            contactFilter.conseillerId = user.id;
            contactFilter.tri = new Tri();
            contactFilter.tri.champ = sortField ? sortField : 'id';
            contactFilter.tri.ascendant = sortOrder && sortOrder === 'ascend' ? true : false;
            contactFilter.pagination = new Pagination();
            contactFilter.pagination.index = pageIndex - 1;
            contactFilter.pagination.limite = pageSize;
          }
        }),
        switchMap(() => this.contactService.getContacts(contactFilter)),
      )
      .subscribe((contacts) => {
        if (contacts) {
          this.listOfContact = contacts.contenu;
          this.total = contacts.total;
          this.ref.markForCheck();
          this.loading = false;
        }
      });
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const { pageSize, pageIndex, sort, filter } = params;
    const currentSort = sort.find((item) => item.value !== null);
    const sortField = (currentSort && currentSort.key) || null;
    const sortOrder = (currentSort && currentSort.value) || null;
    this.loadDataFromServer(pageIndex, pageSize, sortField, sortOrder, filter);
  }

  showModalContact(contact: IContact) {
    const modalRef = this.modalService.create({
      nzTitle: '',
      nzContent: OrganismesModalContactComponent,
      nzFooter: null,
      nzWidth: '800px',
      nzComponentParams: {
        contact,
        users$: of(this.users),
      },
    });

    modalRef.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadDataFromServer(this.pageIndex, this.pageSize, null, null, []);
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
    this.ref.detach();
  }
}
