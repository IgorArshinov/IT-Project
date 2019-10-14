import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import * as fromRouter from '@ngrx/router-store';
import * as fromCustomSerializer from './custom-route-serializer';
import * as fromLoading from './loading.reducer';

export interface State {
  router: fromRouter.RouterReducerState<fromCustomSerializer.RouterStateUrl>;
  loading: fromLoading.LoadingState;
}

export const reducers: ActionReducerMap<State> = {
  router: fromRouter.routerReducer,
  loading: fromLoading.reducer,
};

export const getRouterState = createFeatureSelector<fromRouter.RouterReducerState<fromCustomSerializer.RouterStateUrl>>('router');
export const getLoadingState = createFeatureSelector<fromLoading.LoadingState>('loading');
