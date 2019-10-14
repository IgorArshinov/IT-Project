import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Audio } from '../../../shared/models/audio.model';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';

@Component({
  selector: 'app-audios',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './audios.component.html',
})
export class AudiosComponent implements OnInit {
  audios$: Observable<Audio[]>;

  constructor(private store: Store<fromStore.StudentState>) {}

  ngOnInit(): void {
    this.audios$ = this.store.pipe(select(fromStore.getAudios));
    this.store.dispatch(new fromStore.GetAudios());
  }
}
