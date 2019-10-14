import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { map } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import NavHomeTypeEnum from '../../../shared/models/nav-home-type.enum';
import { ExerciseSeriesModel } from '../../../shared/models/exercise-series.model';
// Do not shorten import to avoid circular dependency
import { CreateExerciseSeriesComponent } from '../create-exercise-series/create-exercise-series.component';
import { faTrash } from '@fortawesome/free-solid-svg-icons/faTrash';

@Component({
  selector: 'app-series-manager',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './series-manager.component.html',
})
export class SeriesManagerComponent implements OnInit {
  trash = faTrash;
  navHomeType = NavHomeTypeEnum.Teacher;

  series$: Observable<ExerciseSeriesModel[]>;
  titleConfiguration = ['Titel', 'Code', 'Aantal oefeningen', 'Moeilijkheidsgraad', 'Acties'];

  niveauFilterString : string[];

  constructor(private store: Store<fromStore.TeacherState>, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.series$ = this.store.pipe(select(fromStore.getAllExerciseSeries));
    this.store.dispatch(new fromStore.GetSeries());
  }

  filter = e =>
    (this.series$ = this.series$.pipe(
      map(series => series.filter(serie =>
        serie.name.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1
        || ('' + serie.code).toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1
      )),
    ));

  removeElement (item) {
    this.store.dispatch (new fromStore.DeleteSeries(item));
  }

  popNewVideoForm() {
    this.dialog.open(CreateExerciseSeriesComponent, { width: '90%', height: '90%', data: {} });
  }

  getOriginalSeries () {
    return this.store.pipe(select(fromStore.getAllExerciseSeries));
  }

  niveauFilter = (niveaus: string[]) => {
    this.niveauFilterString = niveaus;

    if ((niveaus === undefined || niveaus.length === 0 || niveaus[0] === "")) {
      (this.series$ = this.getOriginalSeries())
    } else {
      (this.series$ = this.getOriginalSeries().pipe(
        map(videos => videos.filter(video => niveaus.includes(video.level)))
      ))
    }
  };
}
