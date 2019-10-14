import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import {Observable} from "rxjs";
import {Category} from "../../../shared/models/category.model";
import {select, Store} from "@ngrx/store";
import * as fromStore from "../../store";

@Component({
  selector: 'app-conversation-categories',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './conversation-categories.component.html',
})
export class ConversationCategoriesComponent implements OnInit {
  categories$: Observable<Category[]>;

  constructor(private store: Store<fromStore.StudentState>) {}

  ngOnInit(): void {
    this.categories$ = this.store.pipe(select(fromStore.getCategories));

    this.store.dispatch(new fromStore.GetCategories());
  }
}
