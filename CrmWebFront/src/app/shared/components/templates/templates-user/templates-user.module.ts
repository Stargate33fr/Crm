import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { TemplatesUserComponent } from './templates-user.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [TemplatesUserComponent],
  exports: [TemplatesUserComponent],
  imports: [CommonModule, NgZorroAntdModule, RouterModule],
})
export class TemplatesUserModule {}
