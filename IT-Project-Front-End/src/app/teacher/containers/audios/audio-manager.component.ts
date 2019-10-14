import { Category } from './../../../shared/models/category.model';
import { Audio } from './../../../shared/models/audio.model';
import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as fromStore from '../../store';
import { MatDialog } from '@angular/material';
import { map } from 'rxjs/operators';
import NavHomeTypeEnum from '../../../shared/models/nav-home-type.enum';
import { CreateAudioLessonComponent } from "../../components/create-audio-lesson/create-audio-lesson.component";
import { faPencilAlt } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons/faTrash';

@Component({
  selector: 'app-audio-manager',
  templateUrl: './audio-manager.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AudioManagerComponent implements OnInit {
  navHome = NavHomeTypeEnum.Teacher;
  pencilAlt = faPencilAlt;
  trashIcon = faTrash;

  audios$: Observable<Audio[]>;
  titleConfiguration = ['Titel', 'Categorie', 'Acties'];
  
  categoryFilterString : string[];

  constructor( private store: Store<fromStore.TeacherState>, private dialog: MatDialog ) { }

  ngOnInit(): void {
    this.audios$ = this.getOriginalAudiosFromStore();

    this.store.dispatch(new fromStore.GetCategories());
    this.store.dispatch(new fromStore.GetAudios());
  }

  getOriginalAudiosFromStore() {
    return this.store.pipe(select(fromStore.getAudios));
  }

  filter = e =>
    (this.audios$ = this.audios$.pipe(
      map(audios => audios.filter(audio => audio.name.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1)),
    ));

  categoryFilter = (categories: string[]) =>
  {
    this.categoryFilterString = categories;
    if ((categories === undefined || categories.length === 0 || categories[0] === "")) {
      this.audios$ = this.getOriginalAudiosFromStore()
    } else {
      (this.audios$ = this.getOriginalAudiosFromStore().pipe(
        map(videos => videos.filter(video => categories.includes(video.categoryName)))
      ))
    }
  };

  deleteItem(item: Audio) {
    this.store.dispatch (new fromStore.DeleteAudios(item));
  }

  editElement(item: Audio) {
    this.dialog.open(CreateAudioLessonComponent, { width: '25%', data: item });
  }

  popNewAudioForm() {
    this.dialog.open(CreateAudioLessonComponent, { width: '25%', data: {} });
  }
}
