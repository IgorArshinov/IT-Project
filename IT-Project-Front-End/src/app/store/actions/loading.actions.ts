import { Action } from '@ngrx/store';

export enum LoadingActionTypes {
  LOADING_SHOW = '[SHARED] LOADING_SHOW',
  LOADING_HIDE = '[SHARED] LOADING_HIDE',
}

export class ShowLoading implements Action {
  readonly type = LoadingActionTypes.LOADING_SHOW;
}

export class HideLoading implements Action {
  readonly type = LoadingActionTypes.LOADING_HIDE;
}

export type LoadingAction = ShowLoading | HideLoading;
