import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import * as fromVideo from './video.reducer';
import * as fromCategory from './category.reducer';
import * as fromExercise from './exercise.reducer';
import * as fromAudio from './audio.reducer';
import * as fromExerciseSeries from './series.reducer';


export interface TeacherState {
  videos: fromVideo.VideoState
  categories: fromCategory.CategoryState,
  exercises: fromExercise.ExerciseState,
  audios: fromAudio.AudioState,
  exerciseSeries: fromExerciseSeries.SeriesState,
};

export const reducers: ActionReducerMap<TeacherState> = {
  videos: fromVideo.reducer,
  categories: fromCategory.reducer,
  exercises: fromExercise.reducer,
  audios: fromAudio.reducer,
  exerciseSeries: fromExerciseSeries.reducer
};

export const getTeacherState = createFeatureSelector<TeacherState>('teacher');
