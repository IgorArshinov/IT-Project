import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import { Video } from '../../../shared/models/video.model';
import * as fromStore from '../../store';

@Component({
  selector: 'app-video-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './video-list.component.html',
})
export class VideoListComponent implements OnInit {
  videos$: Observable<Video[]>;

  constructor(private store: Store<fromStore.StudentState>) {}

  ngOnInit(): void {
    this.videos$ = this.store.pipe(select(fromStore.getVideosForCategory));
    this.store.dispatch(new fromStore.GetVideos());
  }
}
