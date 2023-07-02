import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UserRoutingModule } from './user-routing.module';
import { TemplatesUserModule } from '@templates/templates-user/templates-user.module';
import { UserComponent } from './user.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [UserComponent],
  imports: [CommonModule, UserRoutingModule, RouterModule, TemplatesUserModule],
})
export class UserModule {}
