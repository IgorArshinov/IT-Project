import { Action } from '@ngrx/store';
import { Exercise } from '../../../shared/models/exercise.model';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum ExerciseActionTypes {
  GET_EXERCISES = '[Exercise] Get exercises',
  GET_EXERCISES_SUCCESS = '[Exercise] Get exercises SUCCESS',
  GET_EXERCISES_FAIL = '[Exercise] Get exercises FAIL'
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetExercises implements Action {
  readonly type = ExerciseActionTypes.GET_EXERCISES;
}

export class GetExercisesSuccess implements Action {
  readonly type = ExerciseActionTypes.GET_EXERCISES_SUCCESS;

  constructor(public payload: Exercise[]) {
  }
}

export class GetExercisesFail implements Action {
  readonly type = ExerciseActionTypes.GET_EXERCISES_FAIL;
}



/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type ExerciseActions =
  GetExercises
  | GetExercisesSuccess
  | GetExercisesFail
