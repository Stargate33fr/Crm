import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { RoutingKeys } from '@core/rounting/routing-keys';
import { GetUsersLight } from '@core/store/actions/user.action';
import { IAppState } from '@core/store/state/app.state';
import { Store } from '@ngrx/store';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  public routingKey = RoutingKeys;
  title = 'TopInvestV6';
  private destroy$ = new Subject<void>();

  constructor(private store: Store<IAppState>) {}

  ngOnInit(): void {
    this.store.dispatch(new GetUsersLight('allUsers'));
  }
}
