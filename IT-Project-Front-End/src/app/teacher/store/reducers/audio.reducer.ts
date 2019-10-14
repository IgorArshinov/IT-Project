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

    case fromActions.AudioActionTypes.CREATE_AUDIOS_SUCCESS: {
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

    case fromActions.AudioActionTypes.CREATE_AUDIOS_FAIL: {
      return { ...state, data: [] };
    }

    case fromActions.AudioActionTypes.CREATE_AUDIOS: {
      return state;
    }

    case fromActions.AudioActionTypes.DELETE_AUDIOS_SUCCESS: {
      return { ... state, data: state.data.filter (e => e.id !== action.payload.id) };
    }

    default: {
      return state;
    }
  }
}

export const getAudios = (state: AudioState) => state.data;
