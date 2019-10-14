import * as fromActions from '../actions';
import { Exercise } from '../../../shared/models/exercise.model';

export interface ExerciseState {
  data: Exercise[];
  currentExercise: Exercise;
}

const initialState: ExerciseState = {
  data: [],
  currentExercise: null,
};

export function reducer(state: ExerciseState = initialState, action: fromActions.ExerciseActions): ExerciseState {
  switch (action.type) {
    case fromActions.ExerciseActionTypes.GET_EXERCISES_SUCCESS: {
      return {
        ...state,
        data: action.payload,
      };
    }

    case fromActions.ExerciseActionTypes.GET_EXERCISES_FAIL: {
      return {
        ...state,
        data: [],
      };
    }

    case fromActions.ExerciseActionTypes.POST_EXERCISES_SUCCESS: {
      const { payload } = action;
      let newState = { ...state };

      if (state.data.find(x => x.id === action.payload.id) === undefined) {
        newState = { ...state, data: [...state.data, payload] };
      } else {
        newState = { ...state, data: [...state.data.filter(x => x.id !== action.payload.id), payload]};
      }
      return newState;
    }

    case fromActions.ExerciseActionTypes.POST_EXERCISES_FAIL: {
      return {
        ...state,
        data: [],
      };
    }

    case fromActions.ExerciseActionTypes.DELETE_EXERCISES_SUCCESS: {
      return { ...state, data: state.data.filter (e => e.id !== action.payload.id) };
    }

    default: {
      return state;
    }
  }
}

export const getExercises = (state: ExerciseState) => state.data;


// tslint:disable-next-line:triple-equals // Do not change this into === please.
export const getExerciseById = (id) => (state: ExerciseState) => state.data.find(exercise => exercise.id == id);
