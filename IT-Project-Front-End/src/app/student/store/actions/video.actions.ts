import { Action } from '@ngrx/store';
import { Video } from '../../../shared/models/video.model';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum VideoActionTypes {
  GET_VIDEOS = '[Video] Get videos',
  GET_VIDEOS_SUCCESS = '[Video] Get videos SUCCESS',
  GET_VIDEOS_FAIL = '[Video] Get videos FAIL',
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetVideos implements Action {
  readonly type = VideoActionTypes.GET_VIDEOS;
}

export class GetVideosSuccess implements Action {
  readonly type = VideoActionTypes.GET_VIDEOS_SUCCESS;

  constructor(public payload: Video[]) {}
}

export class GetVideosFail implements Action {
  readonly type = VideoActionTypes.GET_VIDEOS_FAIL;
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type VideoActions = GetVideos | GetVideosSuccess | GetVideosFail;
