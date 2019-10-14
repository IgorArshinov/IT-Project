import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { UploadService } from '../../services/upload.service';
import { FormControl, FormGroup } from '@angular/forms';
import { ExerciseType } from '../../../shared/models/exercise.type';
import { Answer } from '../../../shared/models/answer.model';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import config from '../../../api_config';

@Component({
  selector: 'app-multi-audio',
  templateUrl: './multi-audio.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MultiAudioComponent implements OnInit {

  questionUrl: String;
  categories$: Observable<Category[]>;

  form: FormGroup;

  @Output() exercise = new EventEmitter();
  answers: Answer[] = [
    { isCorrect: false, imageUrl: '', audioUrl: '' },
    { isCorrect: false, imageUrl: '', audioUrl: '' },
    { isCorrect: false, imageUrl: '', audioUrl: '' },
    { isCorrect: false, imageUrl: '', audioUrl: '' },
  ];

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
    });

    this.categories$ = this.store.pipe(select(fromStore.getCategories));
    this.store.dispatch(new fromStore.GetCategories());
  }

  submit(aspects) {
    this.exercise.emit({
      ...aspects,
      type: "Multiple choice audio",
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
              default:
                break;
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

  updateAnswer(index, answer: Answer) {
    this.answers[index].imageUrl = answer.imageUrl;
    this.answers[index].audioUrl = answer.audioUrl;
    this.answers[index].isCorrect = answer.isCorrect;
  }
}


