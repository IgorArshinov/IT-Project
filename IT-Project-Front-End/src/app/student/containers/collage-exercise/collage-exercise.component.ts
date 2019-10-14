import { ChangeDetectionStrategy, Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Exercise } from '../../../shared/models/exercise.model';

@Component({
  selector: 'app-collage-exercise',
  templateUrl: './collage-exercise.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CollageExerciseComponent implements OnInit, OnChanges {
  @Input() exercise: Exercise;
  question: HTMLAudioElement;
  moveOn: HTMLAudioElement = new Audio('/assets/ga_naar_de_volgende_oefening.wav');
  right: HTMLAudioElement = new Audio('/assets/juist.wav');
  wrong: HTMLAudioElement = new Audio('/assets/fout.wav');

  constructor() {}

  ngOnInit() {
    this.right.load();
    this.wrong.load();
    this.moveOn.load();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.exercise.currentValue) {
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
}
