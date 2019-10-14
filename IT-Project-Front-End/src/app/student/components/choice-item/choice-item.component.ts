import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Answer } from '../../../shared/models/answer.model';

@Component({
  selector: 'app-choice-item',
  templateUrl: './choice-item.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChoiceItemComponent implements OnInit {
  @Input() answer: Answer;
  @Input() index: number;
  audio: HTMLAudioElement;
  @Output()
  play: EventEmitter<boolean> = new EventEmitter();
  clicked: boolean;

  constructor() {}

  ngOnInit() {
    this.audio = new Audio('/assets/' + this.answer.audioUrl);
  }

  verifyAnswer() {
    this.clicked = true;

    if (this.answer.isCorrect) {
      this.play.emit(true);
    } else {
      this.audio.play();
      this.audio.onended = () => {
        this.play.emit(false);
      };
    }
  }

  getChoiceItemCssClass() {
    if (this.index === 0) return 'first';
    if (this.index === 1) return 'second';
    if (this.index === 2) return 'third';
    if (this.index === 3) return 'fourth';
  }
}
