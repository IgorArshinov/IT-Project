import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromAudio from '../reducers/audio.reducer';
import * as fromCategory from '../selectors/category.selectors';

export const getAudioState = createSelector(
  fromFeature.getTeacherState,
  (state: fromFeature.TeacherState) => state.audios,
);

export const getAudiosWithoutCategory = createSelector(
  getAudioState,
  fromAudio.getAudios,
);

export const getAudios = createSelector (
  getAudiosWithoutCategory,
  fromCategory.getCategories,
  (audios, categories) => {
    return audios.map (audio => {
      return { ... audio, categoryName: categories.find (c => c.id === audio.categoryId).name };
    })
  }
);

