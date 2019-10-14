import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom } from 'rxjs/operators';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/exercise.actions';
import { ExerciseService } from '../../../shared/services/exercise.service';

@Injectable()
export class ExerciseEffects {
  constructor(private actions$: Actions, private exerciseService: ExerciseService, private store: Store<fromRoot.State>) {}

  @Effect() getExercises$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetExercises>(fromActions.ExerciseActionTypes.GET_EXERCISES),
    exhaustMap(() => {
      return this.exerciseService.getExercises().pipe(
        map(result => new fromActions.GetExercisesSuccess(result.data)),
        catchError(() => of(new fromActions.GetExercisesFail())),
      );
    }),
  );
}
