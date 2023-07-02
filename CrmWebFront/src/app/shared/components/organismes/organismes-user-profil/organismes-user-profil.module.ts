import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CustomCurrencyPipeModule } from '@core/pipes/customCurrency.pipe.module';
import { WithLoadingPipeModule } from '@core/pipes/with-loading.pipe.module';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { OrganismesUserProfilComponent } from './organismes-user-profil.component';
import { MoleculesInputNumberModule } from '../../molecules/molecules-input-number/molecules-input-number.module';
import { MoleculesSelectModule } from '../../molecules/molecules-select/molecules-select.module';
import { MoleculesInputModule } from '../../molecules/molecules-input/molecules-input.module';
import { MoleculesAdresseModule } from '../../molecules/molecules-adresse/molecules-adresse.module';
import { FormatTelPipeModule } from '@core/pipes/formatTel.pipe.module';
import { OrganismesModalChangepasswordModule } from '@organismes/organismes-modal-changepassword/organismes-modal-changepassword.module';

@NgModule({
  declarations: [OrganismesUserProfilComponent],
  exports: [OrganismesUserProfilComponent],
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
    OrganismesModalChangepasswordModule,
  ],
})
export class OrganismesUserProfilModule {}
