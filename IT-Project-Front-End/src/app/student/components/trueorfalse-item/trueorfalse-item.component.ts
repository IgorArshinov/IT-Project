import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input, OnChanges,
  OnInit,
  Output, SimpleChanges,
} from '@angular/core';
import { Answer } from "../../../shared/models/answer.model";

@Component({
  selector: 'app-trueorfalse-item',
  templateUrl: './trueorfalse-item.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TrueorfalseItemComponent implements OnInit, OnChanges {
  @Input() asset;
  @Input() answer: Answer;
  audio: HTMLAudioElement;
  @Output()
  play: EventEmitter<boolean> = new EventEmitter();
  clicked: boolean;

  constructor() {
  }

  ngOnInit() {
    this.audio = new Audio('/assets/' + this.answer.audioUrl);
  }

  verifyAnswer() {
    this.clicked = true;

    if (this.answer.isCorrect) {
      this.play.emit(true);
    } else {
      this.play.emit(false);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
      this.clicked = false;
  }
}
