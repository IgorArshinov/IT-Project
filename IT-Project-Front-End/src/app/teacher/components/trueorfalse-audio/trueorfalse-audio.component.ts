import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { UploadService } from '../../services/upload.service';
import { FormControl, FormGroup } from '@angular/forms';
import { ExerciseType } from '../../../shared/models/exercise.type';
import { Answer } from '../../../shared/models/answer.model';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import config from '../../../api_config';

@Component({
  selector: 'app-trueorfalse-audio',
  templateUrl: './trueorfalse-audio.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TrueorfalseAudioComponent implements OnInit {

  questionUrl: String;
  imageUrl: String;
  categories$: Observable<Category[]>;

  form: FormGroup;

  @Output() exercise = new EventEmitter();
  answers: Answer[] = [
    { isCorrect: false, imageUrl: '', audioUrl: '' },
    { isCorrect: false, imageUrl: '', audioUrl: '' },
  ];
  isFirstTrue = true;

  constructor(
    private uploadService: UploadService,
    private cd: ChangeDetectorRef,
    private store: Store<fromStore.TeacherState>,
  ) {
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      title: new FormControl(),
      question: new FormControl(),
      video: new FormControl(),
      image: new FormControl(),
      correct: new FormControl(),
    });

    this.form.controls.correct.valueChanges.subscribe(value => {
      this.toggleIsFirstTrue();
    });

    this.categories$ = this.store.pipe(select(fromStore.getCategories));
    this.store.dispatch(new fromStore.GetCategories());
  }

  submit(aspects) {
    this.exercise.emit({
      ...aspects,
      type: "True or false audio",
      questionUrl: this.questionUrl,
      title: this.form.get('title').value,
      answers: this.answers,
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
              case 'question':
                this.questionUrl = ev.body.data;
                break;
              case 'image':
                this.imageUrl = ev.body.data;
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


  toggleIsFirstTrue() {
    if (this.isFirstTrue) {
      this.answers[0].isCorrect = false;
      this.answers[1].isCorrect = true;
      this.isFirstTrue = false;
    } else {
      this.answers[0].isCorrect = true;
      this.answers[1].isCorrect = false;
      this.isFirstTrue = true;
    }
  }

}


