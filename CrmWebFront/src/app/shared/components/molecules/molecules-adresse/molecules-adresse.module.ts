import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { MoleculesAdresseComponent } from './molecules-adresse.component';
import { MoleculesInputModule } from '../molecules-input/molecules-input.module';

@NgModule({
  declarations: [MoleculesAdresseComponent],
  exports: [MoleculesAdresseComponent],
  imports: [CommonModule, NgZorroAntdModule, ReactiveFormsModule, MoleculesInputModule],
})
export class MoleculesAdresseModule {}
