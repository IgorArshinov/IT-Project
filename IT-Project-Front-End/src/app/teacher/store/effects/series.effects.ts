import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom } from 'rxjs/operators';
import { ExerciseSeriesService } from '../../services/series.service';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/series.actions';

const getSeriesActions = [fromActions.SeriesActionTypes.GET_SERIES, fromActions.SeriesActionTypes.CREATE_SERIES_SUCCESS];

@Injectable()
export class SeriesEffects {
  constructor(private actions$: Actions, private seriesService: ExerciseSeriesService, private store: Store<fromRoot.State>) {}

  @Effect() getExerciseSeries$: Observable<Action> = this.actions$.pipe(
    ofType(...getSeriesActions),
    withLatestFrom(this.store.pipe(select(fromRoot.getRouterState))),
    exhaustMap(([_, router]) => {
      return this.seriesService.getSeries().pipe(
        map(result => {
          return new fromActions.GetSeriesSuccess(result.data)
        }),
        catchError(() => of(new fromActions.GetSeriesFail())),
      );
    }),
  );

  @Effect()
  postExerciseSeries$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.CreateSeries>(fromActions.SeriesActionTypes.CREATE_SERIES),
    exhaustMap(({ payload }) => {
      return !!payload.id
        ? this.seriesService.updateSeries(payload).pipe(
          map(() =>  new fromActions.CreateSeriesSuccess(payload) ),
          catchError(() => of(new fromActions.GetSeriesFail())),
        )
        : this.seriesService.createSeries(payload).pipe(
          map(result => {
            return new fromActions.CreateSeriesSuccess({ ... result.data, id: result['id'] })
          }),
          catchError(() => of(new fromActions.GetSeriesFail())),
        );
    }),
  );

  @Effect()
  DeleteExerciseSeries$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.CreateSeries>(fromActions.SeriesActionTypes.DELETE_SERIES),
    exhaustMap(({ payload }) => {
      return this.seriesService.deleteSeries(payload).pipe(
          map(() =>  new fromActions.DeleteSeriesSuccess(payload) ),
          catchError(() => of(new fromActions.DeleteSeriesFail())),
        )
    }),
  );
}
