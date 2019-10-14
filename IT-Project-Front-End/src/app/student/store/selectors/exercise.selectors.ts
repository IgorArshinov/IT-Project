import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromExercise from '../reducers/exercise.reducer';

export const getExerciseState = createSelector(
  fromFeature.getStudentState,
  (state: fromFeature.StudentState) => state.exercises,
);

export const getExercises = createSelector(
  getExerciseState,
  fromExercise.getExercises,
);

export const getExerciseById = id =>
  createSelector(
    getExerciseState,
    fromExercise.getExerciseById(id),
  );
