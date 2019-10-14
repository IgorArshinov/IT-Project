import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom } from 'rxjs/operators';
import { VideoService } from '../../services/video.service';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/video.actions';

@Injectable()
export class VideoEffects {
  constructor(private actions$: Actions, private categoryService: VideoService, private store: Store<fromRoot.State>) {}

  @Effect() getVideos$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetVideos>(fromActions.VideoActionTypes.GET_VIDEOS),
    withLatestFrom(this.store.pipe(select(fromRoot.getRouterState))),
    exhaustMap(([_, router]) => {
      return this.categoryService.getVideosByCategoryId(router.state.params.id).pipe(
        map(result => new fromActions.GetVideosSuccess(result.data)),
        catchError(() => of(new fromActions.GetVideosFail())),
      );
    }),
  );
}
