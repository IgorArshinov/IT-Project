import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromCategory from '../reducers/category.reducer';

export const getCategoryState = createSelector(
  fromFeature.getTeacherState,
  (state: fromFeature.TeacherState) => state.categories,
);

export const getCategories = createSelector(
  getCategoryState,
  fromCategory.getCategories,
);

