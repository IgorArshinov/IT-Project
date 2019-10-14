import { Component, EventEmitter, Input, Output, TemplateRef, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import { select, Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { Validators } from '@angular/forms';
import { Video } from '../../../shared/models/video.model';

@Component({
  selector: 'app-data-manager',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './data-manager.component.html',
})
export class DataManagerComponent implements OnInit {
  faPlus = faPlus;

  @Input() data$: any[];
  @Input() titleConfiguration: any[];
  @Output() createNew = new EventEmitter<MouseEvent>();
  @Input() template: TemplateRef<HTMLTableDataCellElement>;

  @Output() filter = new EventEmitter<String>();
  @Output() categoryFilter = new EventEmitter<String[]>();
  @Output() niveauFilter = new EventEmitter<String[]>();

  @Input() showFilter = true;
  @Input() showCategoryFilter = false;
  @Input() showNiveauFilter = false;

  categories$: Observable<Category[]>;

  categories = new FormControl();
  categoryList: string[] = [];
  niveaus = new FormControl();
  niveauList: string[] = ["Makkelijk", "Gemiddeld", "Moeilijk"];

  private filterValue: String = '';

  constructor(
    private store: Store<fromStore.TeacherState>
  ) {
  }

  ngOnInit(): void {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));
    this.getFilterCategories();
  }


  emitFilter(event) {
    this.filterValue = event.target.value;
    this.filter.emit(event);
  }

  emitCategoryFilter(event) {
    if (!event) {
      const categoriesFilter = this.categories.value.toString().split(",");
      this.categoryFilter.emit(categoriesFilter);
    }
  }

  emitNiveauFilter(event) {
    if (!event) {
      const niveausFilter = this.niveaus.value.toString().split(",");
      this.niveauFilter.emit(niveausFilter);
    }
  }

  emitCreateNewClick() {
    this.createNew.emit();
  }

  getFilterCategories() {
    this.categories$.forEach((item) => {
      item.forEach((val) => {
        if (val.name !== "") {
          this.categoryList.push(val.name);
        }
      });
    });
  }
}
