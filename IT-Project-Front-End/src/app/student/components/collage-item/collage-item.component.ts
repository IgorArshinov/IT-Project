import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Answer } from '../../../shared/models/answer.model';

@Component({
  selector: 'app-collage-item',
  templateUrl: './collage-item.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CollageItemComponent implements OnInit {
  @Input() answer: Answer;
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
}
