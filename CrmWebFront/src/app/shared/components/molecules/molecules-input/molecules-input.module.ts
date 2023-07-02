import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroAntdModule } from 'src/app/ngZorroAntdmodule';
import { MoleculesInputComponent } from './molecules-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [MoleculesInputComponent],
  exports: [MoleculesInputComponent],
  imports: [CommonModule, NgZorroAntdModule, FormsModule, ReactiveFormsModule],
})
export class MoleculesInputModule {}
