import { Audio } from '../../../shared/models/audio.model';
import * as fromActions from '../actions';

export interface AudioState {
  data: Audio[];
}

const initialState: AudioState = {
  data: [],
};

export function reducer(state: AudioState = initialState, action: fromActions.AudioActions): AudioState {
  switch (action.type) {
    case fromActions.AudioActionTypes.GET_AUDIOS_SUCCESS: {
      return {
        ...state,
        data: action.payload,
      };
    }

    case fromActions.AudioActionTypes.GET_AUDIOS_FAIL: {
      return {
        ...state,
        data: [],
      };
    }

    case fromActions.AudioActionTypes.GET_AUDIOS: {
      return state;
    }

    default: {
      return state;
    }
  }
}

export const getAudios = (state: AudioState) => state.data;
