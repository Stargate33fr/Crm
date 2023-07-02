import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrganismesModalContactComponent } from './organismes-modal-contact.component';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { WithLoadingPipeModule } from '@core/pipes/with-loading.pipe.module';
import { FormatTelPipeModule } from '@core/pipes/formatTel.pipe.module';
import { CustomCurrencyPipeModule } from '@core/pipes/customCurrency.pipe.module';
import { MoleculesInputNumberModule } from '../../molecules/molecules-input-number/molecules-input-number.module';
import { MoleculesSelectModule } from '../../molecules/molecules-select/molecules-select.module';
import { MoleculesInputModule } from '../../molecules/molecules-input/molecules-input.module';
import { MoleculesAdresseModule } from '../../molecules/molecules-adresse/molecules-adresse.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [OrganismesModalContactComponent],
  exports: [OrganismesModalContactComponent],
  imports: [
    CommonModule,
    NgZorroAntdModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    WithLoadingPipeModule,
    CustomCurrencyPipeModule,
    MoleculesInputNumberModule,
    MoleculesSelectModule,
    MoleculesInputModule,
    MoleculesAdresseModule,
    FormatTelPipeModule,
  ],
  providers: [DatePipe],
  entryComponents: [OrganismesModalContactComponent],
})
export class OrganismesModalContactModule {}
