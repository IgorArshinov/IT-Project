import * as fromActions from '../actions';
import { Video } from '../../../shared/models/video.model';

export interface VideoState {
  data: Video[];
}

const initialState: VideoState = {
  data: [],
};

export function reducer(state: VideoState = initialState, action: fromActions.VideoActions): VideoState {
  switch (action.type) {
    case fromActions.VideoActionTypes.GET_VIDEOS_SUCCESS: {
      return {
        ...state,
        data: action.payload,
      };
    }

    case fromActions.VideoActionTypes.GET_VIDEOS_FAIL: {
      return {
        ...state,
        data: [],
      };
    }

    case fromActions.VideoActionTypes.GET_VIDEOS: {
      return state;
    }

    default: {
      return state;
    }
  }
}

export const getVideos = (state: VideoState) => state.data;
