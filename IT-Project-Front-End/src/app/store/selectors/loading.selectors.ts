import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromLoading from '../reducers/loading.reducer';

export const getIsShowing = createSelector(fromFeature.getLoadingState, fromLoading.isShowing);
