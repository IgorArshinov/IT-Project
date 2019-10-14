import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { CollageComponent } from '../../collage/collage.component';
import { MultiAudioComponent } from '../../multi-audio/multi-audio.component';
import { MultiVideoComponent } from '../../multi-video/multi-video.component';
import { TitlePageComponent } from '../../title-page/title-page.component';
import { TrueorfalseAudioComponent } from '../../trueorfalse-audio/trueorfalse-audio.component';
import { TrueorfalseVideoComponent } from '../../trueorfalse-video/trueorfalse-video.component';
import { Store } from '@ngrx/store';
import * as fromStore from '../../../store';

@Component({
  selector: 'app-create-exercise-dialog',
  templateUrl: './create-exercise-dialog.component.html',
})

export class CreateExerciseDialogComponent {
  MULTI_AUDIO = 'MULTI_AUDIO';
  MULTI_VIDEO = 'MULTI_VIDEO ';
  TRUE_OR_FALSE_VIDEO = 'TRUE_OR_FALSE_VIDEO ';
  TRUE_OR_FALSE_AUDIO = 'TRUE_OR_FALSE_AUDIO ';
  TITLEPAGE = 'TITLEPAGE ';
  COLLAGE = 'COLLAGE ';

  constructor(
    private store: Store<fromStore.TeacherState>,
    private router: Router,
    private dialog: MatDialog,
    public dialogReference: MatDialogRef<CreateExerciseDialogComponent>) {
  }

  openForm(type: string) {
    let component;
    switch (type) {
      case this.MULTI_AUDIO:
        component = MultiAudioComponent;
        break;
      case this.MULTI_VIDEO :
        component = MultiVideoComponent;
        break;
      case this.TRUE_OR_FALSE_AUDIO:
        component = TrueorfalseAudioComponent;
        break;
      case this.TRUE_OR_FALSE_VIDEO:
        component = TrueorfalseVideoComponent;
        break;
      case this.TITLEPAGE:
        component = TitlePageComponent;
        break;
      case this.COLLAGE:
        component = CollageComponent;
        break;
    }

    const createFormRef = !!component && this.dialog.open(component, { width: '90%', height: '90%' });
    // @ts-ignore The way createFormRef is assigned, it'll never be clear that the component's instance will have an exercise callback -- N.K.
    createFormRef.componentInstance.exercise.subscribe(e => {
      console.log(e);

      this.store.dispatch(new fromStore.PostExercises(e));

      createFormRef.close();
    });

    this.dialogReference.close();
  }


}
