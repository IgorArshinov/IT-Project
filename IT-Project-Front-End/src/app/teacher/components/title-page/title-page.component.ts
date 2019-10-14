import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { UploadService } from '../../services/upload.service';
import { FormControl, FormGroup } from '@angular/forms';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import config from '../../../api_config';

@Component({
  selector: 'app-title-page',
  templateUrl: './title-page.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TitlePageComponent implements OnInit {

  questionUrl: String;
  imageUrl: String;

  form: FormGroup;

  @Output() exercise = new EventEmitter();
  categories$: Observable<Category[]>;

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
      image: new FormControl(),
    });

    this.categories$ = this.store.pipe(select(fromStore.getCategories));
    this.store.dispatch(new fromStore.GetCategories());
  }

  submit(aspects) {
    this.exercise.emit({
      ...aspects,
      type: "Titelblad",
      questionUrl: this.questionUrl,
      imageUrl: this.imageUrl,
      title: this.form.get('title').value,
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

}


