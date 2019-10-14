import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { VideoManagerComponent } from './videos/video-manager.component';
import { ExercisesManagerComponent } from './exercises/exercises-manager.component';
import { AudioManagerComponent } from './audios/audio-manager.component';
import { SeriesManagerComponent } from './exercise-series/series-manager.component';
import { CreateExerciseSeriesComponent } from './create-exercise-series/create-exercise-series.component';

export const containers: any[] = [
  DashboardComponent,
  LoginComponent,
  RegisterComponent,
  VideoManagerComponent,
  ExercisesManagerComponent,
  AudioManagerComponent,
  SeriesManagerComponent,
  CreateExerciseSeriesComponent
];

export * from './dashboard/dashboard.component';
export * from './login/login.component';
export * from './register/register.component';
export * from './videos/video-manager.component';
export * from './exercises/exercises-manager.component';
export * from './audios/audio-manager.component';
export * from './exercise-series/series-manager.component';
export * from './create-exercise-series/create-exercise-series.component';
