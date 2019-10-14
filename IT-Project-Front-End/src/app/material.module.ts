// material.module.ts

import { NgModule } from '@angular/core';

import {
  MatChipsModule,
  MatDialogModule,
  MatFormFieldModule,
  MatButtonModule,
  MatInputModule,
  MatIconModule
} from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
  exports: [MatIconModule, MatChipsModule, FormsModule, MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule]
})
export class MaterialModule {
}
