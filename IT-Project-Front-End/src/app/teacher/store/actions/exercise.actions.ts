import { Action } from '@ngrx/store';
import { Exercise } from '../../../shared/models/exercise.model';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum ExerciseActionTypes {

  POST_EXERCISES = '[Teacher][Exercise] Post exercises',
  POST_EXERCISES_SUCCESS = '[Teacher][Exercise] Post exercises SUCCESS',
  POST_EXERCISES_FAIL = '[Teacher][Exercise] Post exercises FAIL',
  GET_EXERCISES = '[Teacher][Exercise] Get exercises',
  GET_EXERCISES_SUCCESS = '[Teacher][Exercise] Get exercises SUCCESS',
  GET_EXERCISES_FAIL = '[Teacher][Exercise] Get exercises FAIL',
  DELETE_EXERCISES = '[Teacher][Exercise] Delete exercises',
  DELETE_EXERCISES_SUCCESS = '[Teacher][Exercise] Delete exercises SUCCESS',
  DELETE_EXERCISES_FAIL = '[Teacher][Exercise] Delete exercises FAIL'
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

export class PostExercises implements Action {
  readonly type = ExerciseActionTypes.POST_EXERCISES;

  constructor(public payload: Exercise) {
  }

}

export class PostExercisesSuccess implements Action {
  readonly type = ExerciseActionTypes.POST_EXERCISES_SUCCESS;

  constructor(public payload: Exercise) {
  }
}

export class PostExercisesFail implements Action {
  readonly type = ExerciseActionTypes.POST_EXERCISES_FAIL;
}

export class DeleteExercises implements Action {
  readonly type = ExerciseActionTypes.DELETE_EXERCISES;

  constructor(public payload: Exercise) {
  }

}

export class DeleteExercisesSuccess implements Action {
  readonly type = ExerciseActionTypes.DELETE_EXERCISES_SUCCESS;

  constructor(public payload: Exercise) {
  }
}

export class DeleteExercisesFail implements Action {
  readonly type = ExerciseActionTypes.DELETE_EXERCISES_FAIL;
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type ExerciseActions =
  GetExercises
  | GetExercisesSuccess
  | GetExercisesFail
  | PostExercises
  | PostExercisesSuccess
  | PostExercisesFail
  | DeleteExercises
  | DeleteExercisesSuccess
  | DeleteExercisesFail
