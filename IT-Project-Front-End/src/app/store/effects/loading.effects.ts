import { Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { map } from 'rxjs/operators';

import * as fromLoadingActions from '../actions/loading.actions';

const showLoadingActions = [];

const hideLoadingActions = [];

@Injectable()
export class LoadingEffects {
  @Effect()
  showLoading: Observable<Action> = this.action$.pipe(
    ofType(...showLoadingActions),
    map(() => new fromLoadingActions.ShowLoading()),
  );

  @Effect()
  hideLoading: Observable<Action> = this.action$.pipe(
    ofType(...hideLoadingActions),
    map(() => new fromLoadingActions.HideLoading()),
  );

  constructor(private action$: Actions) {}
}
