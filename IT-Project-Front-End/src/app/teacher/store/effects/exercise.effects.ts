import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Action, Store } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { catchError, exhaustMap, map, tap } from 'rxjs/operators';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/exercise.actions';
import { ExerciseService } from '../../../shared/services/exercise.service';

@Injectable()
export class ExerciseEffects {
  constructor(private actions$: Actions, private exerciseService: ExerciseService, private store: Store<fromRoot.State>) {}

  @Effect() postExercises$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.PostExercises>(fromActions.ExerciseActionTypes.POST_EXERCISES),
    exhaustMap(({payload}) => {
      return this.exerciseService.postExercise(payload).pipe(
        map(result => new fromActions.PostExercisesSuccess(result.data)),
        catchError(() => of(new fromActions.PostExercisesFail())),
      );
    }),
  );

  @Effect() getExercises$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetExercises>(fromActions.ExerciseActionTypes.GET_EXERCISES),
    exhaustMap(() => {
      return this.exerciseService.getExercises().pipe(
        map(result => new fromActions.GetExercisesSuccess(result.data)),
        catchError(() => of(new fromActions.GetExercisesFail())),
      );
    }),
  );

  @Effect()
  DeleteVideo$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.DeleteExercises>(fromActions.ExerciseActionTypes.DELETE_EXERCISES),
    exhaustMap(({ payload }) => {
      return this.exerciseService.deleteExercise(payload).pipe(
        map(() =>  new fromActions.DeleteExercisesSuccess(payload) ),
        catchError(() => of(new fromActions.DeleteExercisesFail())),
      )
    }),
  );
}
