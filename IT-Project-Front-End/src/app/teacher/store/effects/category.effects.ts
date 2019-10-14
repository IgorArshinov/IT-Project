import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { exhaustMap, map, catchError } from 'rxjs/operators';
import { CategoryService } from './../../services/category.service';

import * as fromActions from '../actions/category.actions';

@Injectable()
export class CategoryEffects {
  constructor(private actions$: Actions, private categoryService: CategoryService) {}

  @Effect() getCategories$: Observable<Action> = this.actions$.pipe(
    ofType<fromActions.GetCategories>(fromActions.CategoryActionTypes.GET_CATEGORIES),
    exhaustMap(() =>
      this.categoryService.getCategories().pipe(
        map(result => new fromActions.GetCategoriesSuccess(result.data)),
        catchError(() => of(new fromActions.GetCategoriesFail())),
      ),
    ),
  );
}
