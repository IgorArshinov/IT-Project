import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import * as fromCategory from './category.reducer';
import * as fromVideo from './video.reducer';
import * as fromAudio from './audio.reducer';
import * as fromExercise from './exercise.reducer';
import * as fromExerciseSeries from './exercise-series.reducer'

export interface StudentState {
  categories: fromCategory.CategoryState;
  videos: fromVideo.VideoState;
  audios: fromAudio.AudioState;
  exercises: fromExercise.ExerciseState;
  exerciseSeries: fromExerciseSeries.ExerciseSeriesState;
}

export const reducers: ActionReducerMap<StudentState> = {
  categories: fromCategory.reducer,
  videos: fromVideo.reducer,
  audios: fromAudio.reducer,
  exercises: fromExercise.reducer,
  exerciseSeries: fromExerciseSeries.reducer,
};

export const getStudentState = createFeatureSelector<StudentState>('student');
