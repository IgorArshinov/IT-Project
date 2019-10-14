import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromVideo from '../reducers/video.reducer';
import * as fromCategory from '../selectors/category.selectors';

export const getVideoState = createSelector(
  fromFeature.getTeacherState,
  (state: fromFeature.TeacherState) => state.videos,
);

export const getVideosWithoutCategory = createSelector(
  getVideoState,
  fromVideo.getVideos,
);

export const getVideos = createSelector(
  getVideosWithoutCategory,
  fromCategory.getCategories,
  (videos, categories) => {
    return videos.map(video => {
      return { ...video, categoryName: categories.find(c => c.id === video.categoryId).name };
    });
  },
);
