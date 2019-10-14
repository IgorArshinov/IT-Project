import { Category } from '../../../shared/models/category.model';
import * as fromActions from '../actions';

export interface CategoryState {
  data: Category[];
}

const initialState: CategoryState = {
  data: [],
};

export function reducer(state: CategoryState = initialState, action: fromActions.CategoryActions): CategoryState {
  switch (action.type) {
    case fromActions.CategoryActionTypes.GET_CATEGORIES_SUCCESS: {
      return {
        ...state,
        data: action.payload,
      };
    }

    case fromActions.CategoryActionTypes.GET_CATEGORIES_FAIL: {
      return {
        ...state,
        data: [],
      };
    }

    case fromActions.CategoryActionTypes.GET_CATEGORIES: {
      return state;
    }

    default: {
      return state;
    }
  }
}

export const getCategories = (state: CategoryState) => state.data;
