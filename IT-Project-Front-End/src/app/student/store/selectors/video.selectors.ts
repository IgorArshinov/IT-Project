import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromVideo from '../reducers/video.reducer';

export const getVideoState = createSelector(
  fromFeature.getStudentState,
  (state: fromFeature.StudentState) => state.videos,
);

export const getVideosForCategory = createSelector(
  getVideoState,
  fromVideo.getVideos,
);
