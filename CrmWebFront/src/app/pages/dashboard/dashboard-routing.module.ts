import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { RoutingKeys } from '@core/rounting/routing-keys';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: RoutingKeys.user,
        loadChildren: () => import('../user/user.module').then((m) => m.UserModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
