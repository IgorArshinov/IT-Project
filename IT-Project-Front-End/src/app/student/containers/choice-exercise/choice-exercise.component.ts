import { ChangeDetectionStrategy, Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Exercise } from '../../../shared/models/exercise.model';
import { Video } from '../../../shared/models/video.model';

@Component({
  selector: 'app-choice-exercise',
  templateUrl: './choice-exercise.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChoiceExerciseComponent implements OnInit, OnChanges {
  @Input() exercise: Exercise;
  question: HTMLAudioElement;
  right: HTMLAudioElement = new Audio('/assets/juist.wav');
  wrong: HTMLAudioElement = new Audio('/assets/fout.wav');
  moveOn: HTMLAudioElement = new Audio('/assets/ga_naar_de_volgende_oefening.wav');

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

  query(...args) {
    return args.reduce((acc, curr, index) => `${acc}${index === 0 ? '?' : '&'}${curr}`, '');
  }

  mapExerciseToVideo(exercise: Exercise): Video {
    return {
      id: exercise.id,
      videoUrl: exercise.videoUrl,
    };
  }
}
