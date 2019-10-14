import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action, select, Store } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { catchError, exhaustMap, map, tap, withLatestFrom, mapTo } from 'rxjs/operators';
import { ExerciseSeriesService } from '../../services/exercise-series.service';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/exercise-series.actions';
import * as fromExercisesActions from '../actions/exercise.actions';
import { ExerciseSeriesModel } from '../../../shared/models/exercise-series.model';

@Injectable()
export class ExerciseSeriesEffects {
  constructor(private actions$: Actions, private exerciseSeriesService: ExerciseSeriesService, private store: Store<fromRoot.State>) {}

  @Effect() getExerciseSeries$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetExerciseSeries>(fromActions.ExerciseSeriesActionTypes.GET_EXERCISE_SERIES),
    withLatestFrom(this.store.pipe(select(fromRoot.getRouterState))),
    exhaustMap(([, router]) => {
      return this.exerciseSeriesService.getExerciseSeries(router.state.params.code).pipe(
        map(result => {
          console.log (result);
          return new fromActions.GetExerciseSeriesSuccess(result.data);
        }),
        catchError(() => {
          return of(new fromActions.GetExerciseSeriesFail());
        }),
      );
    }),
  );

  @Effect({ dispatch: false }) getExerciseSeriesExercises: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetExerciseSeriesSuccess>(fromActions.ExerciseSeriesActionTypes.GET_EXERCISE_SERIES_SUCCESS),
    tap(action => {
      console.log (action);
      this.store.dispatch(new fromActions.SetActiveExercise(action.payload.exercises[0]));
    }),
    tap(() => this.store.dispatch(new fromExercisesActions.GetExercises())),
  );
}
