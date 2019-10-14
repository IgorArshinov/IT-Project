import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import { Audio } from '../../../shared/models/audio.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { MAT_DIALOG_DATA, MatDialogRef, MatIconRegistry } from '@angular/material';
import { HttpResponse } from '@angular/common/http';
import { UploadService } from '../../services/upload.service';
import { DomSanitizer } from '@angular/platform-browser';
import { faUpload } from '@fortawesome/free-solid-svg-icons/faUpload';
import { faImage } from '@fortawesome/free-solid-svg-icons/faImage';
import { faVolumeUp } from '@fortawesome/free-solid-svg-icons/faVolumeUp';
import config from '../../../api_config';

@Component({
  selector: 'app-create-audio-lesson',
  templateUrl: './create-audio-lesson.component.html',
})
export class CreateAudioLessonComponent implements OnInit {
  categories$: Observable<Category[]>;
  isLoading = false;
  audio: Audio;

  imageIcon = faImage;
  audioIcon = faVolumeUp;

  lessonForm = new FormGroup({
    name: new FormControl(this.audio && this.audio.name, [Validators.required]),
    categoryId: new FormControl(this.audio && this.audio.categoryId, [Validators.required]),
    fragmentUrl: new FormControl(this.audio && this.audio.fragmentUrl, [Validators.required]),
    imageUrl: new FormControl(this.audio && this.audio.imageUrl, [Validators.required]),
  });

  constructor(
    private uploadService: UploadService,
    private store: Store<fromStore.TeacherState>,
    private cd: ChangeDetectorRef,
    private dialogRef: MatDialogRef<CreateAudioLessonComponent>,
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer,
    @Inject(MAT_DIALOG_DATA) private item,
  ) {
    this.audio = item;
  }

  ngOnInit() {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));
  }

  onCancel() {
    this.lessonForm.reset();
    this.dialogRef.close();
  }

  onSubmit() {
    const audio: Audio = { ...this.audio, ...this.lessonForm.value, type: 'audio' };
    this.store.dispatch(new fromStore.CreateAudios(audio));

    new Promise(resolve => {
      this.isLoading = true;
      setTimeout(resolve, 1000);
    }).then(() => {
      this.dialogRef.close();
      this.isLoading = false;
    });
  }

  upload(event, type) {
    if (event.target.files === 0) {

      console.log('No file selected!');
      return;
    }

    const file: File = event.target.files[0];
    this.uploadService.uploadFile(config.uploadEndpoint, file)
      .subscribe(
        ev => {
          if (ev instanceof HttpResponse) {
            switch (type) {
              case 'fragment':
                this.audio.fragmentUrl = ev.body.data.path;
                break;
              case 'image':
                this.audio.imageUrl = ev.body.data.path;
            }
          }
        },
        (err) => {
          console.log('Upload Error:', err);
          this.cd.detectChanges();
        }, () => {
          this.cd.detectChanges();
        },
      );
  }
}
