import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { TemplatesDashboardComponent } from './templates-dashboard.component';
import { RouterModule } from '@angular/router';
import { OrganismesModalContactModule } from '@organismes/organismes-modal-contact/organismes-modal-contact.module';

@NgModule({
  declarations: [TemplatesDashboardComponent],
  exports: [TemplatesDashboardComponent],
  imports: [CommonModule, NgZorroAntdModule, RouterModule, OrganismesModalContactModule],
})
export class TemplatesDashboardModule {}
