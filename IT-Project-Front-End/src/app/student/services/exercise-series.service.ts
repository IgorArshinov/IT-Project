import { ExerciseSeries } from '../../shared/models/exercise.series';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseObject } from '../../shared/models/response-object.model';
import config from '../../api_config'

const API_URL = `${config.url}/exerciseSeries`;

@Injectable({ providedIn: 'root' })
export class ExerciseSeriesService {
  constructor(private http: HttpClient) {}

  getExerciseSeries(code: number) {
    return this.http.get<ResponseObject<ExerciseSeries>>(`${API_URL}/${code}`);
  }
}
