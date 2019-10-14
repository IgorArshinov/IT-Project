import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromExerciseSeries from '../reducers/series.reducer';
// import * as fromCategory from '../selectors/category.selectors';

export const getExerciseSeriesState = createSelector(
  fromFeature.getTeacherState,
  (state: fromFeature.TeacherState) => state.exerciseSeries,
);

export const getAllExerciseSeries = createSelector(
  getExerciseSeriesState,
  fromExerciseSeries.getExerciseSeries,
);

// export const getVideos = createSelector(
//   getVideosWithoutCategory,
//   fromCategory.getCategories,
//   (videos, categories) => {
//     return videos.map(video => {
//       return { ...video, categoryName: categories.find(c => c.id === video.categoryId).name };
//     });
//   },
// );
