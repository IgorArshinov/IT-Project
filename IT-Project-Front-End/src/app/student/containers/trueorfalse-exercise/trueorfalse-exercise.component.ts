import { ChangeDetectionStrategy, Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Exercise } from '../../../shared/models/exercise.model';
import { DomSanitizer } from '@angular/platform-browser';
import { Video } from '../../../shared/models/video.model';

@Component({
  selector: 'app-trueorfalse-exercise',
  templateUrl: './trueorfalse-exercise.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TrueorfalseExerciseComponent implements OnInit, OnChanges {
  @Input() exercise: Exercise;
  videoUrl: string;
  video: Video;
  question: HTMLAudioElement;
  moveOn: HTMLAudioElement = new Audio('/assets/ga_naar_de_volgende_oefening.wav');
  right: HTMLAudioElement = new Audio('/assets/juist.wav');
  wrong: HTMLAudioElement = new Audio('/assets/fout.wav');

  answer1;
  answer2;

  constructor(public sanitizer: DomSanitizer) {
  }

  ngOnInit() {
    this.right.load();
    this.wrong.load();
    this.moveOn.load();


  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log ('hoi');
    if (changes.exercise.currentValue) {
      this.videoUrl = this.exercise.videoUrl;
      this.video = {
        videoUrl: this.exercise.videoUrl,
      };
      this.question = new Audio('/assets/' + this.exercise.questionUrl);
      this.question.load();
      this.question.play();
    }
    this.answer1 = this.exercise.answers[0];
    this.answer2 = this.exercise.answers[1];
  }

  playQuestion() {
    this.question.play();
  }

  play(event: boolean) {
    if (event) {
      this.right.play();
      this.right.addEventListener('ended', () => this.moveOn.play());
    } else {
      this.wrong.play();
    }
  }

  query(...args) {
    return args.reduce((acc, curr, index) => `${acc}${index === 0 ? '?' : '&'}${curr}`, '');
  }
}
