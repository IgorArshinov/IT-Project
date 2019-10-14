import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-nav-next',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './nav-next.component.html',
})
export class NavNextComponent {
  @Output() nextButtonClicked = new EventEmitter();

  constructor() {}

  buttonClicked() {
    this.nextButtonClicked.emit();
  }
}
