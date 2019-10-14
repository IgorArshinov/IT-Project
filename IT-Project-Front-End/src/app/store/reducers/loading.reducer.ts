import { LoadingAction, LoadingActionTypes } from '../actions/loading.actions';

export interface LoadingState {
  show: boolean;
}

const initialState: LoadingState = {
  show: false,
};

export function reducer(state: LoadingState = initialState, action: LoadingAction) {
  switch (action.type) {
    case LoadingActionTypes.LOADING_SHOW:
      return { ...state, show: true };
    case LoadingActionTypes.LOADING_HIDE:
      return { ...state, show: false };
    default:
      return state;
  }
}

export const isShowing = (state: LoadingState) => state.show;
