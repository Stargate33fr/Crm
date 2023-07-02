import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { UserProfilComponent } from './user-profil.component';
import { TemplatesProfilModule } from '@templates/templates-profil/templates-profil.module';
import { UserProfilRoutingModule } from './user-profil-routing.module';

@NgModule({
  declarations: [UserProfilComponent],
  imports: [CommonModule, UserProfilRoutingModule, TemplatesProfilModule],
})
export class UserProfilModule {}
