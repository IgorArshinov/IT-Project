import { Audio } from '../../shared/models/audio.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseObject } from '../../shared/models/response-object.model';
import config from '../../api_config'

const API_URL = `${config.url}/audios`;

@Injectable({ providedIn: 'root' })
export class AudioService {
  constructor(private http: HttpClient) {}

  getAudios(categoryId: number) {
    return this.http.get<ResponseObject<Audio[]>>(`${API_URL}?categoryId=${categoryId}`);
  }
}
