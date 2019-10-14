import { Component, ChangeDetectionStrategy } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ChoicesComponent } from '../../../root-components/choices/choices.component';
import { NavHomeTypeEnum } from '../../../shared/models/nav-home-type.enum';

@Component({
  selector: 'app-dashboard',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent {
  navHomeType = NavHomeTypeEnum.Teacher;

  Links = {
    CONVERSATION: '/teacher/conversations',
    VIDEO: '/teacher/videos',
    COLLAGE: '/teacher/collages',
    SERIES: [{ title: 'Alle oefeningen', url: '/teacher/exercises' }, { title: 'Alle oefenreeksen', url: '/teacher/exercise-series' }],
  };

  constructor(private dialog: MatDialog) {}

  showDialog = data => this.dialog.open(ChoicesComponent, { data });
}
