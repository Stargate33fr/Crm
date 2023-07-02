import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { RoutingKeys } from '@core/rounting/routing-keys';

const routes: Routes = [
  {
    path: '',
    component: UserComponent,
    children: [
      {
        path: RoutingKeys.profil,
        loadChildren: () => import('./user-profil/user-profil.module').then((m) => m.UserProfilModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
