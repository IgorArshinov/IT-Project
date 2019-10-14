import { Component, ChangeDetectionStrategy, Input, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-choices',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './choices.component.html',
})
export class ChoicesComponent {
  choices;

  constructor (
    @Inject(MAT_DIALOG_DATA) private injectedChoices,
    private router: Router,
    public dialogRef: MatDialogRef<ChoicesComponent>
  ) {
    this.choices = injectedChoices;
  }

  navigateTo(url){
    this.dialogRef.close();
    this.router.navigateByUrl(url);
  }
}
