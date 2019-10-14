import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { CdkDrag, CdkDragMove, CdkDropList, CdkDropListGroup, moveItemInArray } from '@angular/cdk/drag-drop';
import { faArrowsAlt, faCopy, faPencilAlt, faTrash } from '@fortawesome/free-solid-svg-icons';

import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { Category } from '../../../shared/models/category.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MatIconRegistry } from '@angular/material';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { ViewportRuler } from '@angular/cdk/overlay';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ConfirmationDialogComponent } from '../../../root-components';
import { AddExerciseDialogComponent } from '../../components';
import { ExerciseLevel } from '../../../shared/models/exercise-level.enum';
import { ExerciseSeriesModel } from '../../../shared/models/exercise-series.model';

@Component({
  selector: 'app-create-exercise-series',
  templateUrl: './create-exercise-series.component.html',
})
export class CreateExerciseSeriesComponent implements OnInit, AfterViewInit {
  deleteIcon = faTrash;
  copyIcon = faCopy;
  moveIcon = faArrowsAlt;
  editIcon = faPencilAlt;
  isLoading = false;

  categories$: Observable<Category[]>;
  exerciseSeries: ExerciseSeriesModel = {
    name: '',
    exercises: [],
    code: 0,
    level: undefined,
  } as ExerciseSeriesModel;

  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  @ViewChild(CdkDropListGroup) listGroup: CdkDropListGroup<CdkDropList>;
  @ViewChild(CdkDropList) placeholder: CdkDropList;

  target: CdkDropList;
  targetIndex: number;
  source: CdkDropList;
  sourceIndex: number;
  activeContainer;

  exerciseLevel = ExerciseLevel;
  exerciseSeriesForm = new FormGroup({
    name: new FormControl(this.exerciseSeries && this.exerciseSeries.name, [Validators.required, Validators.maxLength(40)]),
    level: new FormControl(this.exerciseSeries && this.exerciseSeries['level']),
    exercises: new FormControl(this.exerciseSeries.exercises && this.exerciseSeries.exercises),
  });

  constructor(
    private changeDetector: ChangeDetectorRef,
    private router: Router,
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer,
    private store: Store<fromStore.TeacherState>,
    private dialog: MatDialog,
    private viewportRuler: ViewportRuler,
    private dialogRef: MatDialogRef<CreateExerciseSeriesComponent>,
  ) {
    this.target = null;
    this.source = null;
  }

  ngOnInit() {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));
    this.store.dispatch(new fromStore.GetCategories());
  }

  ngAfterViewInit() {
    const phElement = this.placeholder.element.nativeElement;

    phElement.style.display = 'none';
    phElement.parentElement.removeChild(phElement);
  }

  submit() {
    this.updateFormControlExercises();
    console.log('Creating new exercise series', this.exerciseSeries, this.exerciseSeriesForm.getRawValue());
    const toBeSent: ExerciseSeriesModel = {
      ...this.exerciseSeries,
      exercises: this.exerciseSeries.exercises.map(e => e.id),
    };

    this.store.dispatch(new fromStore.CreateSeries(toBeSent));

    new Promise(resolve => {
      this.isLoading = true;
      setTimeout(resolve, 1000);
    }).then(() => {
      this.dialogRef.close();
      this.isLoading = false;
    });
  }

  resetForm() {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: 'Alle velden resetten?',
    });

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.exerciseSeriesForm.reset();
        this.exerciseSeries.exercises = [];
        this.updateFormControlExercises();
        this.changeDetector.detectChanges();
      }
    });

  }

  updateFormControlExercises() {
    this.exerciseSeriesForm.controls['exercises'].setValue(this.exerciseSeries.exercises);
  }

  addExercise = () => {
    const addExerciseDialog = this.dialog.open(AddExerciseDialogComponent);
    addExerciseDialog.componentInstance.addedExercises.subscribe(e => {
      console.log('in actual creator form', e);
      this.exerciseSeries.exercises = [...e];
    });
  };

  deleteExercise(index: number) {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: 'Verwijderen?',
    });

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.exerciseSeries.exercises.splice(index, 1);
        this.changeDetector.detectChanges();
      }
    });

  }

  duplicateExercise(index: number) {
    this.exerciseSeries.exercises = [...this.exerciseSeries.exercises, this.exerciseSeries.exercises[index]];
  }

  dragMoved(e: CdkDragMove) {
    const point = this.getPointerPositionOnPage(e.event);

    this.listGroup._items.forEach(dropList => {
      if (__isInsideDropListClientRect(dropList, point.x, point.y)) {
        this.activeContainer = dropList;
        return;
      }
    });
  }

  dropListDropped() {
    if (!this.target)
      return;

    const phElement = this.placeholder.element.nativeElement;
    const parent = phElement.parentElement;

    phElement.style.display = 'none';

    parent.removeChild(phElement);
    parent.appendChild(phElement);
    parent.insertBefore(this.source.element.nativeElement, parent.children[this.sourceIndex]);

    this.target = null;
    this.source = null;

    if (this.sourceIndex !== this.targetIndex)
      moveItemInArray(this.exerciseSeries.exercises, this.sourceIndex, this.targetIndex);
  }

  dropListEnterPredicate = (drag: CdkDrag, drop: CdkDropList) => {
    if (drop === this.placeholder)
      return true;

    if (drop !== this.activeContainer)
      return false;

    const phElement = this.placeholder.element.nativeElement;
    const sourceElement = drag.dropContainer.element.nativeElement;
    const dropElement = drop.element.nativeElement;

    const dragIndex = __indexOf(dropElement.parentElement.children, (this.source ? phElement : sourceElement));
    const dropIndex = __indexOf(dropElement.parentElement.children, dropElement);

    if (!this.source) {
      this.sourceIndex = dragIndex;
      this.source = drag.dropContainer;

      phElement.style.width = sourceElement.clientWidth + 'px';
      phElement.style.height = sourceElement.clientHeight + 'px';

      sourceElement.parentElement.removeChild(sourceElement);
    }

    this.targetIndex = dropIndex;
    this.target = drop;

    phElement.style.display = '';
    dropElement.parentElement.insertBefore(phElement, (dropIndex > dragIndex
      ? dropElement.nextSibling : dropElement));

    this.placeholder.enter(drag, drag.element.nativeElement.offsetLeft, drag.element.nativeElement.offsetTop);
    return false;
  };

  /** Determines the point of the page that was touched by the user. */
  getPointerPositionOnPage(event: MouseEvent | TouchEvent) {
    // `touches` will be empty for start/end events so we have to fall back to `changedTouches`.
    const point = __isTouchEvent(event) ? (event.touches[0] || event.changedTouches[0]) : event;
    const scrollPosition = this.viewportRuler.getViewportScrollPosition();

    return {
      x: point.pageX - scrollPosition.left,
      y: point.pageY - scrollPosition.top,
    };
  }
}

function __indexOf(collection, node) {
  return Array.prototype.indexOf.call(collection, node);
};

/** Determines whether an event is a touch event. */
function __isTouchEvent(event: MouseEvent | TouchEvent): event is TouchEvent {
  return event.type.startsWith('touch');
}

function __isInsideDropListClientRect(dropList: CdkDropList, x: number, y: number) {
  const { top, bottom, left, right } = dropList.element.nativeElement.getBoundingClientRect();
  return y >= top && y <= bottom && x >= left && x <= right;
}

