import { Injectable } from '@angular/core';
import { Observable, of, from } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom } from 'rxjs/operators';
import { AudioService } from '../../services/audio.service';

import * as fromRoot from '../../../store';
import * as fromActions from '../actions/audio.actions';

@Injectable()
export class AudioEffects {
  constructor(private actions$: Actions, private audioService: AudioService, private store: Store<fromRoot.State>) {}

  @Effect() getAudios$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetAudios>(fromActions.AudioActionTypes.GET_AUDIOS),
    withLatestFrom(this.store.pipe(select(fromRoot.getRouterState))),
    exhaustMap(([_, router]) =>
      this.audioService.getAudios(router.state.params.id).pipe(
        map(result => new fromActions.GetAudiosSuccess(result.data)),
        catchError(() => of(new fromActions.GetAudiosFail())),
      ),
    ),
  );
}
