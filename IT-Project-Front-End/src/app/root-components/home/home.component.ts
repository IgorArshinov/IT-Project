import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { PopupComponent } from './popup/popup.component';
import { MatDialog } from '@angular/material';
import { Store } from '@ngrx/store';
import * as fromStudentStore from '../../student/store';

@Component({
  selector: 'app-home',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(public dialog: MatDialog, private store: Store<fromStudentStore.StudentState>) {}
  openDialog = () => this.dialog.open(PopupComponent, {});

  ngOnInit() {
    this.store.dispatch(new fromStudentStore.ClearActiveExercise());
  }
}
