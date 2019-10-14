import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormArray } from '@angular/forms';
import { Exercise } from '../../../shared/models/exercise.model';
import { Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { ExerciseType } from '../../../shared/models/exercise.type';


@Component({
  selector: 'app-create-exercise',
  templateUrl: './create-exercise.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateExerciseComponent implements OnInit {
  type: ExerciseType;

  types = ExerciseType;

  exercise: Exercise = {} as Exercise;

  answers: FormArray;

  constructor(
    private store: Store<fromStore.TeacherState>,
    private router: Router,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.type = ExerciseType[params.get('type')];
    });
  }

  submit(exercise: Exercise) {
    this.store.dispatch(new fromStore.PostExercises(exercise));
  }
}
