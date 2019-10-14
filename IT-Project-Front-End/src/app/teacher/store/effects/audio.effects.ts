import { Injectable } from '@angular/core';
import { Observable, of, from } from 'rxjs';
import { Action, Store, select } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError, withLatestFrom, tap } from 'rxjs/operators';
import { AudioService } from '../../services/audio.service';

import * as fromActions from '../actions/audio.actions';

@Injectable()
export class AudioEffects {
  constructor(private actions$: Actions, private audioService: AudioService) {}

  @Effect() getAudios$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetAudios>(fromActions.AudioActionTypes.GET_AUDIOS),
    exhaustMap(() =>
      this.audioService.getAudios().pipe(
        map(result => new fromActions.GetAudiosSuccess(result.data)),
        catchError(() => of(new fromActions.GetAudiosFail())),
      ),
    ),
  );

  @Effect()
  postAudio$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.CreateAudios>(fromActions.AudioActionTypes.CREATE_AUDIOS),
    exhaustMap(({ payload }) => {
      return !!payload.id
        ? this.audioService.updateAudio(payload).pipe(
          map(() => new fromActions.CreateAudiosSuccess(payload)),
          catchError(() => of(new fromActions.GetAudiosFail())),
        )
        : this.audioService.createAudio(payload).pipe(
          map(result => new fromActions.CreateAudiosSuccess(result.data)),
          catchError(() => of(new fromActions.GetAudiosFail())),
        );
    }),
  );

  @Effect() deleteAudio$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.DeleteAudios>(fromActions.AudioActionTypes.DELETE_AUDIOS),
    exhaustMap(({ payload }) =>
      this.audioService.deleteAudio(payload).pipe(
        map(() => new fromActions.DeleteAudiosSuccess(payload)),
        catchError(() => of(new fromActions.DeleteAudiosFail())),
      ),
    ),
  );
}
