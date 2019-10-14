import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Exercise } from '../models/exercise.model';
import { ResponseObject } from '../models/response-object.model';
import config from '../../api_config'

const API_URL = `${config.url}`;
const EXERCISE_URI = '/exercises';

@Injectable({ providedIn: 'root' })
export class ExerciseService {
  constructor(private http: HttpClient) {
  }

  getExercises() {
    return this.http.get<ResponseObject<Exercise[]>>(`${API_URL}${EXERCISE_URI}`);
  }

  postExercise(data: Exercise) {
    return this.http.post<ResponseObject<Exercise>>(`${API_URL}${EXERCISE_URI}`, { data });
  }

  deleteExercise (data: Exercise) {
    return this.http.delete<void>(`${API_URL}${EXERCISE_URI}/${data.id}`);
  }
}
