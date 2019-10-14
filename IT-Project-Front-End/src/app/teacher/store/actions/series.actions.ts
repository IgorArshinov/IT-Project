import { Action } from '@ngrx/store';
import { ExerciseSeriesModel } from '../../../shared/models/exercise-series.model';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum SeriesActionTypes {
  GET_SERIES = '[Teacher][Series] Get Series',
  GET_SERIES_SUCCESS = '[Teacher][Series] Get Series SUCCESS',
  GET_SERIES_FAIL = '[Teacher][Series] Get Series FAIL',
  CREATE_SERIES = '[Teacher][Series] Create Series',
  CREATE_SERIES_SUCCESS = '[Teacher][Series] Create Series SUCCESS',
  CREATE_SERIES_FAIL = '[Teacher][Series] Create Series FAIL',
  DELETE_SERIES = '[Teacher][Series] Delete Series',
  DELETE_SERIES_SUCCESS = '[Teacher][Series] Delete Series SUCCESS',
  DELETE_SERIES_FAIL = '[Teacher][Series] Delete Series FAIL',
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetSeries implements Action {
  readonly type = SeriesActionTypes.GET_SERIES;
}

export class GetSeriesSuccess implements Action {
  readonly type = SeriesActionTypes.GET_SERIES_SUCCESS;

  constructor(public payload: ExerciseSeriesModel[]) {}
}

export class GetSeriesFail implements Action {
  readonly type = SeriesActionTypes.GET_SERIES_FAIL;
}

export class CreateSeries implements Action {
  readonly type = SeriesActionTypes.CREATE_SERIES;
  constructor (public payload: ExerciseSeriesModel) {}
}

export class CreateSeriesSuccess implements Action {
  readonly type = SeriesActionTypes.CREATE_SERIES_SUCCESS;

  constructor(public payload: ExerciseSeriesModel) {}
}

export class CreateSeriesFail implements Action {
  readonly type = SeriesActionTypes.CREATE_SERIES_FAIL;
}

export class DeleteSeries implements Action {
  readonly type = SeriesActionTypes.DELETE_SERIES;
  constructor (public payload: ExerciseSeriesModel) {}
}

export class DeleteSeriesSuccess implements Action {
  readonly type = SeriesActionTypes.DELETE_SERIES_SUCCESS;

  constructor(public payload: ExerciseSeriesModel) {}
}

export class DeleteSeriesFail implements Action {
  readonly type = SeriesActionTypes.DELETE_SERIES_FAIL;
}
/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type SeriesActions = GetSeries | GetSeriesSuccess | GetSeriesFail
  | CreateSeries | CreateSeriesFail | CreateSeriesSuccess
  | DeleteSeries | DeleteSeriesFail | DeleteSeriesSuccess;
