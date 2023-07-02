import { CommonModule, DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { WithLoadingPipeModule } from '@core/pipes/with-loading.pipe.module';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { OrganismesModalChangepasswordComponent } from './organismes-modal-changepassword.component';

@NgModule({
  declarations: [OrganismesModalChangepasswordComponent],
  exports: [OrganismesModalChangepasswordComponent],
  imports: [CommonModule, ReactiveFormsModule, NgZorroAntdModule, WithLoadingPipeModule, RouterModule],
  entryComponents: [OrganismesModalChangepasswordComponent],
  providers: [DatePipe],
})
export class OrganismesModalChangepasswordModule {}
