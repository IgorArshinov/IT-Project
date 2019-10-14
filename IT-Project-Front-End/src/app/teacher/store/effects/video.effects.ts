import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom } from 'rxjs/operators';
import { VideoService } from '../../services/video.service';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/video.actions';

const getVideosActions = [fromActions.VideoActionTypes.GET_VIDEOS, fromActions.VideoActionTypes.CREATE_VIDEOS_SUCCESS];

@Injectable()
export class VideoEffects {
  constructor(private actions$: Actions, private videoService: VideoService, private store: Store<fromRoot.State>) {}

  @Effect() getVideos$: Observable<Action> = this.actions$.pipe(
    ofType(...getVideosActions),
    withLatestFrom(this.store.pipe(select(fromRoot.getRouterState))),
    exhaustMap(([_, router]) => {
      return this.videoService.getVideos().pipe(
        map(result => new fromActions.GetVideosSuccess(result.data)),
        catchError(() => of(new fromActions.GetVideosFail())),
      );
    }),
  );

  @Effect()
  postVideo$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.CreateVideos>(fromActions.VideoActionTypes.CREATE_VIDEOS),
    exhaustMap(({ payload }) => {
      return !!payload.id
        ? this.videoService.updateVideo(payload).pipe(
            map(() => {
              return new fromActions.CreateVideosSuccess(payload);
            }),
            catchError(() => of(new fromActions.GetVideosFail())),
          )
        : this.videoService.createVideo(payload).pipe(
            map(result => new fromActions.CreateVideosSuccess(result.data)),
            catchError(() => of(new fromActions.GetVideosFail())),
          );
    }),
  );

  @Effect()
  DeleteVideo$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.DeleteVideos>(fromActions.VideoActionTypes.DELETE_VIDEOS),
    exhaustMap(({ payload }) => {
      return this.videoService.deleteVideo(payload).pipe(
        map(() =>  new fromActions.DeleteVideosSuccess(payload) ),
        catchError(() => of(new fromActions.DeleteVideosFail())),
      )
    }),
  );
}
