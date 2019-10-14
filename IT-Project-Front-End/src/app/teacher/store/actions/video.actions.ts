import { Action } from '@ngrx/store';
import { Video } from '../../../shared/models/video.model';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum VideoActionTypes {
  GET_VIDEOS = '[Teacher][Video] Get videos',
  GET_VIDEOS_SUCCESS = '[Teacher][Video] Get videos SUCCESS',
  GET_VIDEOS_FAIL = '[Teacher][Video] Get videos FAIL',
  CREATE_VIDEOS = '[Teacher][Video] Create videos',
  CREATE_VIDEOS_SUCCESS = '[Teacher][Video] Create videos SUCCESS',
  CREATE_VIDEOS_FAIL = '[Teacher][Video] Create videos FAIL',
  DELETE_VIDEOS = '[Teacher][Video] Delete videos',
  DELETE_VIDEOS_SUCCESS = '[Teacher][Video] Delete videos SUCCESS',
  DELETE_VIDEOS_FAIL = '[Teacher][Video] Delete videos FAIL',
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

export class CreateVideos implements Action {
  readonly type = VideoActionTypes.CREATE_VIDEOS;
  constructor (public payload: Video) {}
}

export class CreateVideosSuccess implements Action {
  readonly type = VideoActionTypes.CREATE_VIDEOS_SUCCESS;

  constructor(public payload: Video) {}
}

export class CreateVideosFail implements Action {
  readonly type = VideoActionTypes.CREATE_VIDEOS_FAIL;
}

export class DeleteVideos implements Action {
  readonly type = VideoActionTypes.DELETE_VIDEOS;
  constructor (public payload: Video) {}
}

export class DeleteVideosSuccess implements Action {
  readonly type = VideoActionTypes.DELETE_VIDEOS_SUCCESS;
  constructor (public payload: Video) {}
}

export class DeleteVideosFail implements Action {
  readonly type = VideoActionTypes.DELETE_VIDEOS_FAIL;
}
/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type VideoActions = GetVideos | GetVideosSuccess | GetVideosFail |
  CreateVideos | CreateVideosFail | CreateVideosSuccess |
  DeleteVideos | DeleteVideosFail | DeleteVideosSuccess ;
