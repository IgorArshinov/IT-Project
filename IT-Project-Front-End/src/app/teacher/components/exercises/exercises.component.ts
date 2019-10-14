import { Component, Input, OnInit } from '@angular/core';
import { Exercise } from "../../../shared/models/exercise.model";
import { CdkDrag, CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { select } from "@ngrx/store";

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html'
})
export class ExercisesComponent implements OnInit {

  @Input() exercises: any[];
  initialExercisesCount: number;
  selectedExercises = [];

  constructor() {
  }

  drop( event: CdkDragDrop<string[]> ) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  ngOnInit() {
    console.log('data', this.initialExercisesCount);
    console.log('data', this.exercises.length);

    this.initialExercisesCount = this.exercises.length;
    console.log('data', this.initialExercisesCount);

  }

  onCreate() {
    console.log(this.selectedExercises);
  }

  async onReset() {

    console.log('data', this.initialExercisesCount);

    if (this.initialExercisesCount !== this.exercises.length) {
      this.exercises = [
        { title: 'Get to work' },
        { title: 'Pick up groceries' },
        { title: 'Go home' },
        { title: 'Fall asleep' }
      ];
      // this.store.pipe(select('teacher')).subscribe(
      //   exercises => {
      //     this.exercises = exercises['exercises']['data'];
      //     console.log('data', exercises);
      //   })

      // this.allExercises$.subscribe(allExercises => {
      //   this.allExercises = allExercises;
      // });

      this.selectedExercises = [];
    }

  }

}
