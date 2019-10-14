import { Category } from '../../../shared/models/category.model';
import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as fromStore from '../../store';

@Component({
  selector: 'app-audio-categories',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './audio-categories.component.html',
})
export class AudioCategoriesComponent implements OnInit {
  categories$: Observable<Category[]>;

  constructor(private store: Store<fromStore.StudentState>) {}

  ngOnInit(): void {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));

    this.store.dispatch(new fromStore.GetCategories());
  }
}
