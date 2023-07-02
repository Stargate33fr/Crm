import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { TemplatesUserProfilComponent } from './templates-user-profil.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [TemplatesUserProfilComponent],
  exports: [TemplatesUserProfilComponent],
  imports: [CommonModule, NgZorroAntdModule, RouterModule],
})
export class TemplatesUserProfilModule {}
