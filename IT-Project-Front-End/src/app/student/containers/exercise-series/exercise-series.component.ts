import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as fromStore from '../../store';
import { ExerciseSeries } from '../../../shared/models/exercise.series';
import { Exercise } from '../../../shared/models/exercise.model';

@Component({
  selector: 'app-exercise-series',
  templateUrl: './exercise-series.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExerciseSeriesComponent implements OnInit {
  exerciseSeriesCode;
  exerciseSeries$: Observable<ExerciseSeries>;
  exercises$: Observable<Exercise[]>;
  activeExercise$: Observable<Exercise>;

  question: HTMLAudioElement;
  right: HTMLAudioElement = new Audio('/assets/juist.wav');
  wrong: HTMLAudioElement = new Audio('/assets/fout.wav');
  moveOn: HTMLAudioElement = new Audio('/assets/ga_naar_de_volgende_oefening.wav');

  constructor(private store: Store<fromStore.StudentState>, private route: ActivatedRoute) {}

  ngOnInit() {
    this.exerciseSeriesCode = this.route.snapshot.paramMap.get('code');
    this.right.load();
    this.wrong.load();
    this.moveOn.load();

    this.store.dispatch(new fromStore.GetExerciseSeries());
    this.exerciseSeries$ = this.store.pipe(select(fromStore.getExerciseSeries));
    this.exercises$ = this.store.pipe(select(fromStore.getExerciseSeriesExercises));
    this.activeExercise$ = this.store.pipe(select(fromStore.getActiveExercise));
  }

  onGoToNext() {
    this.store.dispatch(new fromStore.NextActiveExercise());
  }

  isLastExercise(exerciseSeries: ExerciseSeries, activeExercise: Exercise) {
    if (exerciseSeries && activeExercise) return activeExercise.id !== exerciseSeries.exercises[exerciseSeries.exercises.length - 1];
    else return false;
  }

  isExerciseType(exercise: Exercise, type: 'true or false' | 'multiple choice') {
    const exerciseTypes = [type, `${type} audio`, `${type} video`];
    return exerciseTypes.includes(exercise.type.toLowerCase());
  }
}
