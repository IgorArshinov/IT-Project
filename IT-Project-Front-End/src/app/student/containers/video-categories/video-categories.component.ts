import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Category } from '../../../shared/models/category.model';
import * as fromStore from '../../store';

@Component({
  selector: 'app-video-categories',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './video-categories.component.html',
})
export class VideoCategoriesComponent implements OnInit {
  categories$: Observable<Category[]>;

  constructor(private store: Store<fromStore.StudentState>) {}

  ngOnInit(): void {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));

    this.store.dispatch(new fromStore.GetCategories());
  }
}
