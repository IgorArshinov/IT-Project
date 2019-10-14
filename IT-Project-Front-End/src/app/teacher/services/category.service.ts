import { Category } from '../../shared/models/category.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseObject } from '../../shared/models/response-object.model';
import { config }  from '../../api_config';

const API_URL = `${config.url}/categories`;

@Injectable({ providedIn: 'root' })
export class CategoryService {
  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<ResponseObject<Category[]>>(`${API_URL}`);
  }

}
