import { Audio } from '../../../shared/models/audio.model';
import { Action } from '@ngrx/store';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum AudioActionTypes {
  GET_AUDIOS = '[Teacher] [Audio] Get audios',
  GET_AUDIOS_SUCCESS = '[Teacher] [Audio] Get audios SUCCESS',
  GET_AUDIOS_FAIL = '[Teacher] [Audio] Get audios FAIL',
  CREATE_AUDIOS = '[Teacher][Audio] Create audios',
  CREATE_AUDIOS_SUCCESS = '[Teacher][Audio] Create audios SUCCESS',
  CREATE_AUDIOS_FAIL = '[Teacher][Audio] Create audios FAIL',
  DELETE_AUDIOS = '[Teacher][Audio] Delete audios',
  DELETE_AUDIOS_SUCCESS = '[Teacher][Audio] Delete audios SUCCESS',
  DELETE_AUDIOS_FAIL = '[Teacher][Audio] Delete audios FAIL',
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetAudios implements Action {
  readonly type = AudioActionTypes.GET_AUDIOS;
}

export class GetAudiosSuccess implements Action {
  readonly type = AudioActionTypes.GET_AUDIOS_SUCCESS;

  constructor(public payload: Audio[]) {}
}

export class GetAudiosFail implements Action {
  readonly type = AudioActionTypes.GET_AUDIOS_FAIL;
}

export class CreateAudios implements Action {
  readonly type = AudioActionTypes.CREATE_AUDIOS;
  constructor (public payload: Audio) {}
}

export class CreateAudiosSuccess implements Action {
  readonly type = AudioActionTypes.CREATE_AUDIOS_SUCCESS;

  constructor(public payload: Audio) {}
}

export class CreateAudiosFail implements Action {
  readonly type = AudioActionTypes.CREATE_AUDIOS_FAIL;
}

export class DeleteAudios implements Action {
  readonly type = AudioActionTypes.DELETE_AUDIOS;
  constructor (public payload: Audio) {}
}

export class DeleteAudiosSuccess implements Action {
  readonly type = AudioActionTypes.DELETE_AUDIOS_SUCCESS;

  constructor(public payload: Audio) {}
}

export class DeleteAudiosFail implements Action {
  readonly type = AudioActionTypes.DELETE_AUDIOS_FAIL;
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type AudioActions = GetAudios | GetAudiosSuccess | GetAudiosFail
  | CreateAudios | CreateAudiosFail | CreateAudiosSuccess
  | DeleteAudios | DeleteAudiosFail | DeleteAudiosSuccess ;
