import { Action } from '@ngrx/store';
import { ExerciseSeries } from '../../../shared/models/exercise.series';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum ExerciseSeriesActionTypes {
  GET_EXERCISE_SERIES = '[ExerciseSeriesModel] Get exercises series',
  GET_EXERCISE_SERIES_SUCCESS = '[ExerciseSeriesModel] Get exercise series SUCCESS',
  GET_EXERCISE_SERIES_FAIL = '[ExerciseSeriesModel] Get exercise series FAIL',
  SET_ACTIVE_EXERCISE = '[ExerciseSeries] Set current exercise',
  CLEAR_ACTIVE_EXERCISE = '[ExerciseSeries] Clear current exercise',
  NEXT_ACTIVE_EXERCISE = '[ExerciseSeries] Next exercise',
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetExerciseSeries implements Action {
  readonly type = ExerciseSeriesActionTypes.GET_EXERCISE_SERIES;
}

export class GetExerciseSeriesSuccess implements Action {
  readonly type = ExerciseSeriesActionTypes.GET_EXERCISE_SERIES_SUCCESS;

  constructor(public payload: ExerciseSeries) {}
}
export class GetExerciseSeriesFail implements Action {
  readonly type = ExerciseSeriesActionTypes.GET_EXERCISE_SERIES_FAIL;
}

export class SetActiveExercise implements Action {
  readonly type = ExerciseSeriesActionTypes.SET_ACTIVE_EXERCISE;

  constructor(public payload: number) {}
}

export class ClearActiveExercise implements Action {
  readonly type = ExerciseSeriesActionTypes.CLEAR_ACTIVE_EXERCISE;
}

export class NextActiveExercise implements Action {
  readonly type = ExerciseSeriesActionTypes.NEXT_ACTIVE_EXERCISE;
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type ExerciseSeriesActions =
  | GetExerciseSeries
  | GetExerciseSeriesSuccess
  | GetExerciseSeriesFail
  | SetActiveExercise
  | ClearActiveExercise
  | NextActiveExercise;
