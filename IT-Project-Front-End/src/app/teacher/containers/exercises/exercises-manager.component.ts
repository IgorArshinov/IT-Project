import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { map } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import NavHomeTypeEnum from '../../../shared/models/nav-home-type.enum';
import { Exercise } from '../../../shared/models/exercise.model';
import { CreateExerciseDialogComponent } from '../../components/add-exercise-dialog/create-exercise-dialog/create-exercise-dialog.component';
import { faTrash } from '@fortawesome/free-solid-svg-icons/faTrash';

@Component({
  selector: 'app-video-exercises-manager',
  changeDetection: ChangeDetectionStrategy.Default,
  templateUrl: './exercises-manager.component.html',
})
export class ExercisesManagerComponent implements OnInit {
  trashIcon = faTrash;

  @Input() selectable: Boolean = false;
  @Output() selectedItems = new EventEmitter<any[]> ();

  itemsInSelection = [];
  titleConfiguration = [];

  navHomeType = NavHomeTypeEnum.Teacher;

  exercises$: Observable<Exercise[]>;

  categoryFilterString : string[];

  constructor(private store: Store<fromStore.TeacherState>, private dialog: MatDialog ) {}

  ngOnInit(): void {
    this.titleConfiguration = this.selectable
      ? ['', 'Titel', 'Type', 'Categorie', 'Aantal antwoorden']
      : [ 'Titel', 'Type', 'Categorie', 'Aantal antwoorden', 'Acties'];

    this.exercises$ = this.store.pipe(select(fromStore.getExercises));

    this.store.dispatch(new fromStore.GetCategories());
    this.store.dispatch(new fromStore.GetExercises());
  }

  filter = e => this.exercises$ = this.exercises$.pipe (
    map( items => items.filter (item => {
      return (
        (item.title.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1)
        ||
        (item.type.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1)
      )
    }) )
  );

  emitSelect (event, item: Exercise) {
    this.itemsInSelection = !! event.checked ? [... this.itemsInSelection, item] :  this.itemsInSelection.filter(e => item.id !== e.id);
    this.selectedItems.emit(this.itemsInSelection);
  }

  popNewVideoForm () {
    this.dialog.open(CreateExerciseDialogComponent, {});
  }

  getOriginalExercisesFromStore() {
    return this.store.pipe(select(fromStore.getExercises));
  }

  categoryFilter = (categories: string[]) =>
  {
    this.categoryFilterString = categories;

    if ((categories === undefined || categories.length === 0 || categories[0] === "")) {
      this.exercises$ = this.getOriginalExercisesFromStore()
    } else {
      (this.exercises$ = this.getOriginalExercisesFromStore().pipe(
        map(videos => videos.filter(video => categories.includes(video.categoryName)))
      ))
    }
  };

  deleteItem(item: Exercise) {
    this.store.dispatch (new fromStore.DeleteExercises(item));
  }
}
