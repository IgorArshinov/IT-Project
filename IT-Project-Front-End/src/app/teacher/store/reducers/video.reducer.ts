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
      return { ...state, data: action.payload };
    }

    case fromActions.VideoActionTypes.GET_VIDEOS_FAIL: {
      return { ...state, data: [] };
    }

    case fromActions.VideoActionTypes.GET_VIDEOS: {
      return state;
    }

    case fromActions.VideoActionTypes.CREATE_VIDEOS_SUCCESS: {
      const { payload } = action;
      let newState;

      if (state.data.find(e => e.id === payload.id)) {
        const newData = state.data;
        newData.splice(state.data.findIndex(v => v.id === payload.categoryId), 1, payload);
        newState = { ...state, data: newData };
      } else {
        newState = { ...state, data: [...state.data, payload] };
      }

      return newState;
    }

    case fromActions.VideoActionTypes.CREATE_VIDEOS_FAIL: {
      return { ...state, data: [] };
    }

    case fromActions.VideoActionTypes.CREATE_VIDEOS: {
      return state;
    }

    case fromActions.VideoActionTypes.DELETE_VIDEOS_SUCCESS: {
      return { ... state, data: state.data.filter (e => e.id !== action.payload.id)};
    }

    case fromActions.VideoActionTypes.DELETE_VIDEOS_FAIL: {
      return { ... state };
    }

    default: {
      return state;
    }
  }
}

export const getVideos = (state: VideoState) => state.data;
