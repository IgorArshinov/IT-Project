import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { Answer } from '../../../shared/models/answer.model';
import { HttpResponse } from '@angular/common/http';
import { UploadService } from '../../services/upload.service';
import { FormControl, FormGroup } from '@angular/forms';
import config from '../../../api_config'

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AnswerComponent implements OnInit {
  @Output() answerChanged = new EventEmitter();
  answer: Answer = {isCorrect: false, imageUrl: '', audioUrl: ''};
  @Input() letter: string;

  form: FormGroup;

  constructor(
    private uploadService: UploadService,
    private cd: ChangeDetectorRef,
  ) {
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      image: new FormControl(),
      audio: new FormControl(),
      correct: new FormControl(),
    });

    this.form.valueChanges.subscribe(val => {
      this.answer.isCorrect = !this.answer.isCorrect;
      this.answerChanged.emit(this.answer);
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
              case 'audio':
                this.answer.audioUrl = ev.body.data;
                this.answerChanged.emit(this.answer);
                break;
              case 'image':
                this.answer.imageUrl = ev.body.data;
                this.answerChanged.emit(this.answer);
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
}
