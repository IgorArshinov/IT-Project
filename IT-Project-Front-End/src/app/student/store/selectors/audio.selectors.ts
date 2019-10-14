import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromAudio from '../reducers/audio.reducer';

export const getAudioState = createSelector(
  fromFeature.getStudentState,
  (state: fromFeature.StudentState) => state.audios,
);

export const getAudios = createSelector(
  getAudioState,
  fromAudio.getAudios,
);
