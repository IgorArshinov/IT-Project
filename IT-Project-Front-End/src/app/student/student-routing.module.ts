import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  VideoCategoriesComponent,
  AudioCategoriesComponent,
  ConversationCategoriesComponent,
  VideoListComponent,
  AudiosComponent,
  CollageExerciseComponent,
  ChoiceExerciseComponent,
  TrueorfalseExerciseComponent,
} from './containers';
import { ExerciseSeriesComponent } from './containers/exercise-series/exercise-series.component';

const routes: Routes = [
  {
    path: 'videos',
    component: VideoCategoriesComponent,
    pathMatch: 'full',
  },
  {
    path: 'videos/:id',
    component: VideoListComponent,
    pathMatch: 'full',
  },
  {
    path: 'audios',
    component: AudioCategoriesComponent,
    pathMatch: 'full',
  },
  {
    path: 'audios/:id',
    component: AudiosComponent,
    pathMatch: 'full',
  },
  {
    path: 'audios/:id/:subid',
    redirectTo: 'audios/:id',
    pathMatch: 'full',
  },
  {
    path: 'conversations',
    component: ConversationCategoriesComponent,
    pathMatch: 'full',
  },
  {
    path: 'exercise/series/:code',
    component: ExerciseSeriesComponent,
    pathMatch: 'full',
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
export class StudentRoutingModule {}
