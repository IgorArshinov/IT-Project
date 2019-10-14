import { Category } from '../../../shared/models/category.model';
import { Action } from '@ngrx/store';

/**
 * For each action type in an action group, make a simple
 * enum object for all of this group's action types.
 */
export enum CategoryActionTypes {
  GET_CATEGORIES = '[Category] Get categories',
  GET_CATEGORIES_SUCCESS = '[Category] Get categories SUCCESS',
  GET_CATEGORIES_FAIL = '[Category] Get categories FAIL',
}

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 */
export class GetCategories implements Action {
  readonly type = CategoryActionTypes.GET_CATEGORIES;
}

export class GetCategoriesSuccess implements Action {
  readonly type = CategoryActionTypes.GET_CATEGORIES_SUCCESS;

  constructor(public payload: Category[]) {}
}

export class GetCategoriesFail implements Action {
  readonly type = CategoryActionTypes.GET_CATEGORIES_FAIL;
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type CategoryActions = GetCategories | GetCategoriesSuccess | GetCategoriesFail;
