import { Audio } from '../../../shared/models/audio.model';
import { Action } from '@ngrx/store';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum AudioActionTypes {
  GET_AUDIOS = '[Audio] Get audios',
  GET_AUDIOS_SUCCESS = '[Audio] Get audios SUCCESS',
  GET_AUDIOS_FAIL = '[Audio] Get audios FAIL',
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

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type AudioActions = GetAudios | GetAudiosSuccess | GetAudiosFail;
