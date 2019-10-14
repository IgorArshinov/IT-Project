import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExerciseSeriesModel } from '../../shared/models/exercise-series.model';
import { ResponseObject } from '../../shared/models/response-object.model';
import config from '../../api_config'

const API_URL = `${config.url}`;
const SERIES_URI = '/exerciseSeries';

@Injectable({ providedIn: 'root' })
export class ExerciseSeriesService {
  constructor(private http: HttpClient) {}

  getSeries() {
    return this.http.get<ResponseObject<ExerciseSeriesModel[]>>(`${API_URL}${SERIES_URI}`);
  }

  createSeries(data: ExerciseSeriesModel) {
    return this.http.post<ResponseObject<ExerciseSeriesModel>>(`${API_URL}${SERIES_URI}`, { data });
  }

  updateSeries(data: ExerciseSeriesModel) {
    return this.http.put<ResponseObject<ExerciseSeriesModel>>(`${API_URL}${SERIES_URI}/${data.id}`, { data });
  }

  deleteSeries(data: ExerciseSeriesModel) {
    return this.http.delete<ResponseObject<ExerciseSeriesModel>>(`${API_URL}${SERIES_URI}/${data.id}`);
  }
}
