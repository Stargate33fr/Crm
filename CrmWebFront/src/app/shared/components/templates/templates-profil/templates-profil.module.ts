import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { TemplatesProfilComponent } from './templates-profil.component';
import { OrganismesUserProfilModule } from '@organismes/organismes-user-profil/organismes-user-profil.module';

@NgModule({
  declarations: [TemplatesProfilComponent],
  exports: [TemplatesProfilComponent],
  imports: [CommonModule, NgZorroAntdModule, ReactiveFormsModule, OrganismesUserProfilModule],
})
export class TemplatesProfilModule {}
