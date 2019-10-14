import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  DashboardComponent,
  LoginComponent,
  RegisterComponent,
  ExercisesManagerComponent,
  VideoManagerComponent,
  AudioManagerComponent,
  CreateExerciseSeriesComponent,
} from './containers';
import { AuthGuard } from './guards/auth.guard';
import { CreateExerciseComponent } from './containers/create-exercise/create-exercise.component';
import { SeriesManagerComponent } from './containers/exercise-series/series-manager.component';
import { CreateExerciseDialogComponent, CreateVideoLessonComponent } from "./components";

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'exercise-series/create',
    component: CreateExerciseSeriesComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'videos',
    component: VideoManagerComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'exercise/:type',
    component: CreateExerciseComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'create',
    component: CreateExerciseDialogComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'createExerciseSeries/video',
    component: CreateVideoLessonComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'collages',
    component: AudioManagerComponent,
  },
  {
    path: 'exercises',
    component: ExercisesManagerComponent,
  },
  {
    path: 'exercise-series',
    component: SeriesManagerComponent,
  },
  {
    path: '',
    redirectTo: '/',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherRoutingModule {}
