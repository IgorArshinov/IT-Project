import { ChangeDetectorRef, Component, Inject, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Video } from '../../../shared/models/video.model';

@Component({
  selector: 'app-create-video-lesson',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './create-video-lesson.component.html',
})
export class CreateVideoLessonComponent implements OnInit {
  categories$: Observable<Category[]>;
  isLoading = false;
  video: Video;

  lessonForm = new FormGroup({
    name: new FormControl(this.video && this.video.name, [Validators.required]),
    categoryId: new FormControl(this.video && this.video.categoryId, [Validators.required]),
    videoUrl: new FormControl(this.video && this.video.videoUrl, [Validators.required, Validators.pattern('.*youtube.*\\/embed.*')]),
  });

  constructor(
    private store: Store<fromStore.TeacherState>,
    private dialogRef: MatDialogRef<CreateVideoLessonComponent>,
    @Inject(MAT_DIALOG_DATA) private item,
  ) {
    this.video = item;
  }

  ngOnInit(): void {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));
  }

  onCancel() {
    this.lessonForm.reset();
    this.dialogRef.close();
  }

  onSubmit() {
    const video: Video = { ...this.video, ...this.lessonForm.value, type: 'video' };
    this.store.dispatch(new fromStore.CreateVideos(video));

    new Promise(resolve => {
      this.isLoading = true;
      setTimeout(resolve, 1000);
    }).then(() => {
      this.dialogRef.close();
      this.isLoading = false;
    });
  }
}
