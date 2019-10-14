import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromExercise from '../reducers/exercise.reducer';
import * as fromCategory from '../selectors/category.selectors';

export const getExerciseState = createSelector(
  fromFeature.getTeacherState,
  (state: fromFeature.TeacherState) => state.exercises,
);

export const getExercisesWithoutCategory = createSelector (
  getExerciseState,
  fromExercise.getExercises
);

export const getExercises = createSelector (
  getExercisesWithoutCategory,
  fromCategory.getCategories,
  (exercises, categories) => {
    return exercises.map (ex => {
      return { ... ex, categoryName: categories.find (c => c.id === ex.categoryId).name };
    })
  }
);

export const getExerciseById = (id) => createSelector(
  getExerciseState,
  fromExercise.getExerciseById(id),
);

