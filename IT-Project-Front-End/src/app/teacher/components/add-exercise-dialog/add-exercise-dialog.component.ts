import { Component, ChangeDetectionStrategy, Output, EventEmitter } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { CreateExerciseDialogComponent } from './create-exercise-dialog/create-exercise-dialog.component';
import { ExercisesManagerComponent } from '../../containers/exercises/exercises-manager.component';

@Component({
  selector: 'app-add-exercise-dialog',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './add-exercise-dialog.component.html',
})
export class AddExerciseDialogComponent {
  @Output() addedExercises = new EventEmitter<any[]>();

  menuTitels = [
    { title: 'Zoek in alle werkbladen', url: '/teacher/exercises' },
    { title: 'Nieuw Werkblad', url: '/teacher/createExerciseSeries' },
  ];

  constructor(
    private router: Router,
    public dialogReference: MatDialogRef<AddExerciseDialogComponent>,
    private dialog: MatDialog,
  ) {
  }

  openPopup = data => {
    this.dialog.open(CreateExerciseDialogComponent, { });
    this.dialogReference.close();
  };

  openSelector = () => {
    const ref = this.dialog.open(ExercisesManagerComponent, { height: '70%', width: '70%' });
    ref.componentInstance.selectable = true;
    ref.componentInstance.selectedItems.subscribe(e => {
      this.addedExercises.emit(e);
    });

    this.dialogReference.close();
  };
}
