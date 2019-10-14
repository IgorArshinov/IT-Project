import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { NavHomeTypeEnum } from '../../models/nav-home-type.enum';

@Component({
  selector: 'app-nav-home',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './nav-home.component.html',
})
export class NavHomeComponent {
  teacher = NavHomeTypeEnum.Teacher;

  @Input () mode = NavHomeTypeEnum.Student;
}
