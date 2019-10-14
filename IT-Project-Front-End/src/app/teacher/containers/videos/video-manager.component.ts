import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable, empty } from 'rxjs';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { Video } from '../../../shared/models/video.model';
import { map } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { CreateVideoLessonComponent } from '../../components';
import NavHomeTypeEnum from '../../../shared/models/nav-home-type.enum';
import { faPencilAlt } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons/faTrash';

@Component({
  selector: 'app-video-manager',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './video-manager.component.html',
})
export class VideoManagerComponent implements OnInit {
  pencilAlt = faPencilAlt;
  trashIcon = faTrash;
  navHomeType = NavHomeTypeEnum.Teacher;

  videos$: Observable<Video[]>;
  titleConfiguration = ['Titel', 'Categorie', 'Acties'];

  categoryFilterString : string[];

  constructor(private store: Store<fromStore.TeacherState>, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.videos$ = this.getOriginalVideosFromStore();

    this.store.dispatch(new fromStore.GetCategories());
    this.store.dispatch(new fromStore.GetVideos());
  }

  getOriginalVideosFromStore() {
    return this.store.pipe(select(fromStore.getVideos));
  }

  filter = e =>
    (this.videos$ = this.videos$.pipe(
      map(videos => videos.filter(video => video.name.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1))
    ));

  categoryFilter = (categories: string[]) => 
  {
    this.categoryFilterString = categories;
    if (categories === undefined || categories.length === 0 || categories[0] === "") {
      (this.videos$ = this.getOriginalVideosFromStore())
    } else {
      (this.videos$ = this.getOriginalVideosFromStore().pipe(
        map(videos => videos.filter(video => categories.includes(video.categoryName)))
      ))
    }
  };

  deleteVideo (video: Video) {
    this.store.dispatch(new fromStore.DeleteVideos(video));
  }

  editElement(item) {
    this.dialog.open(CreateVideoLessonComponent, { width: '25%', data: item });
  }

  popNewVideoForm() {
    // alert ('to be implemented.');
    this.dialog.open(CreateVideoLessonComponent, { width: '25%', data: {} });
  }
}
