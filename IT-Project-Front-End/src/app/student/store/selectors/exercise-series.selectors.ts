import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromExerciseSeries from '../reducers/exercise-series.reducer';
import * as fromExercises from './exercise.selectors';

export const getExerciseSeriesState = createSelector(
  fromFeature.getStudentState,
  (state: fromFeature.StudentState) => state.exerciseSeries,
);

export const getExerciseSeries = createSelector(
  getExerciseSeriesState,
  fromExerciseSeries.getExerciseSeries,
);

export const getExerciseSeriesExercises = createSelector(
  getExerciseSeries,
  fromExercises.getExercises,
  (exerciseSeries, exercises) => {
    return exercises.filter(exercise => exerciseSeries.exercises.includes(exercise.id));
  },
);

export const getActiveExerciseId = createSelector(
  getExerciseSeriesState,
  fromExerciseSeries.getActiveExerciseId,
);

export const getActiveExercise = createSelector(
  getExerciseSeriesExercises,
  getActiveExerciseId,
  (exercises, activeExerciseId) => {
    return exercises.find(exercise => exercise.id === activeExerciseId);
  },
);
