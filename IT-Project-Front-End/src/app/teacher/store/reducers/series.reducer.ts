import * as fromActions from '../actions';
import { ExerciseSeriesModel } from '../../../shared/models/exercise-series.model';

export interface SeriesState { data: ExerciseSeriesModel[]; }

const initialState: SeriesState = { data: [], };

export function reducer(state: SeriesState = initialState, action: fromActions.SeriesActions): SeriesState {
  switch (action.type) {
    case fromActions.SeriesActionTypes.GET_SERIES_SUCCESS: {
      return { ...state, data: action.payload };
    }

    case fromActions.SeriesActionTypes.GET_SERIES_FAIL: {
      return { ...state, data: [] };
    }

    case fromActions.SeriesActionTypes.GET_SERIES: {
      return state;
    }

    case fromActions.SeriesActionTypes.CREATE_SERIES_SUCCESS: {
      const { payload } = action;
      let newState;

      if (state.data.find(e => e.id === payload.id)) {
        const newData = { ... state.data };
        // newData.splice(state.data.findIndex(v => v.id === payload.categoryId), 1, payload);
        newState = { ...state, data: newData };
      } else {
        newState = { ...state, data: [...state.data, payload] };
      }

      return newState;
    }

    case fromActions.SeriesActionTypes.CREATE_SERIES_FAIL: {
      return { ...state, data: [] };
    }

    case fromActions.SeriesActionTypes.CREATE_SERIES: {
      return state;
    }

    case fromActions.SeriesActionTypes.DELETE_SERIES_SUCCESS: {
      return { ...state, data: state.data.filter (e => e.id !== action.payload.id) };
    }

    case fromActions.SeriesActionTypes.DELETE_SERIES_FAIL: {
      return { ...state };
    }

    default: {
      return state;
    }
  }
}

export const getExerciseSeries = (state: SeriesState) => state.data;
