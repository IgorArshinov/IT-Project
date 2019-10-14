import { ChangeDetectionStrategy, Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Exercise } from '../../../shared/models/exercise.model';
import { DomSanitizer } from '@angular/platform-browser';
import { Video } from '../../../shared/models/video.model';

@Component({
  selector: 'app-titlepage',
  templateUrl: './titlepage.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TitlepageComponent implements OnInit, OnChanges {
  @Input() exercise: Exercise;
  imageUrl: string;
  question: HTMLAudioElement;
  moveOn: HTMLAudioElement = new Audio('/assets/ga_naar_de_volgende_oefening.wav');
  right: HTMLAudioElement = new Audio('/assets/juist.wav');
  wrong: HTMLAudioElement = new Audio('/assets/fout.wav');

  constructor(public sanitizer: DomSanitizer) {}

  ngOnInit() {
    this.right.load();
    this.wrong.load();
    this.moveOn.load();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.exercise.currentValue) {
      this.imageUrl = this.exercise.imageUrl;
      this.question = new Audio('/assets/' + this.exercise.questionUrl);
      this.question.load();
      this.question.play();
    }
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
