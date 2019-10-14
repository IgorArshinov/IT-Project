import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { SharedModule } from '../shared/shared.module';
import { TeacherRoutingModule } from './teacher-routing.module';

import { containers, CreateExerciseSeriesComponent } from './containers';
import {
  components,
  CreateVideoLessonComponent,
  CreateAudioLessonComponent,
  AddExerciseDialogComponent,
  MultiAudioComponent,
  MultiVideoComponent, TrueorfalseVideoComponent, TrueorfalseAudioComponent, TitlePageComponent, CollageComponent,
} from './components';
import { reducers } from './store/reducers';
import { effects } from './store/effects';
import {
  MatButtonModule,
  MatCardModule, MatCheckboxModule,
  MatFormFieldModule, MatIconModule,
  MatInputModule, MatProgressBarModule, MatProgressSpinnerModule,
  MatRadioModule,
  MatSelectModule, MatStepperModule,
  MatTableModule, MatTooltipModule,
  MatChipsModule
} from '@angular/material';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { LoginComponent } from './containers/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './containers';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FakeAuthInterceptor } from './interceptors/fake-auth.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CreateExerciseComponent } from './containers/create-exercise/create-exercise.component';
import { ExercisesComponent } from './components/exercises/exercises.component';

@NgModule({
  declarations: [...containers, ...components, LoginComponent, RegisterComponent, CreateExerciseComponent, ExercisesComponent],
  exports: [CreateVideoLessonComponent, CreateExerciseSeriesComponent],
  entryComponents: [CreateVideoLessonComponent, CreateAudioLessonComponent, AddExerciseDialogComponent, MultiAudioComponent, MultiVideoComponent,
    TrueorfalseVideoComponent, TrueorfalseAudioComponent, TitlePageComponent, CollageComponent],
  imports: [
    DragDropModule,
    CommonModule,
    SharedModule,
    TeacherRoutingModule,
    StoreModule.forFeature('teacher', reducers),
    EffectsModule.forFeature(effects),
    MatButtonModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    MatChipsModule,
    MatIconModule,
    MatRadioModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSelectModule,
    MatStepperModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatTooltipModule,
    MatCheckboxModule,
    MatCardModule,
    MatIconModule
  ],
  providers: [

  ],
})
export class TeacherModule {
}
