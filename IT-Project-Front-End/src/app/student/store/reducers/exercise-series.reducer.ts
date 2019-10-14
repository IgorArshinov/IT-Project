import * as fromActions from '../actions';
import { ExerciseSeries } from '../../../shared/models/exercise.series';
import { Exercise } from './../../../shared/models/exercise.model';

export interface ExerciseSeriesState {
  data: ExerciseSeries;
  activeExerciseId: number | null;
}

const initialState: ExerciseSeriesState = {
  data: null,
  activeExerciseId: null,
};

export function reducer(state: ExerciseSeriesState = initialState, action: fromActions.ExerciseSeriesActions): ExerciseSeriesState {
  switch (action.type) {
    case fromActions.ExerciseSeriesActionTypes.GET_EXERCISE_SERIES_SUCCESS: {
      return {
        ...state,
        data: action.payload,
      };
    }

    case fromActions.ExerciseSeriesActionTypes.GET_EXERCISE_SERIES_FAIL: {
      return {
        ...state,
        data: null,
      };
    }

    case fromActions.ExerciseSeriesActionTypes.GET_EXERCISE_SERIES: {
      return state;
    }

    case fromActions.ExerciseSeriesActionTypes.SET_ACTIVE_EXERCISE: {
      return {
        ...state,
        activeExerciseId: action.payload,
      };
    }

    case fromActions.ExerciseSeriesActionTypes.CLEAR_ACTIVE_EXERCISE: {
      return {
        ...state,
        activeExerciseId: null,
      };
    }

    case fromActions.ExerciseSeriesActionTypes.NEXT_ACTIVE_EXERCISE: {
      const { activeExerciseId } = state;
      const { data: exerciseSeries } = state;
      const indexOfActiveItem = exerciseSeries.exercises.indexOf(activeExerciseId);

      let newActiveExerciseId = activeExerciseId;

      if (!(indexOfActiveItem === exerciseSeries.exercises.length - 1)) {
        newActiveExerciseId = exerciseSeries.exercises[indexOfActiveItem + 1];
      }

      return {
        ...state,
        activeExerciseId: newActiveExerciseId,
      };
    }

    default: {
      return state;
    }
  }
}

export const getExerciseSeries = (state: ExerciseSeriesState) => state.data;
export const getActiveExerciseId = (state: ExerciseSeriesState) => state.activeExerciseId;
