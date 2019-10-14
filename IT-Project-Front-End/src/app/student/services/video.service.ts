import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Video } from '../../shared/models/video.model';
import { ResponseObject } from '../../shared/models/response-object.model';
import config from '../../api_config';

const API_URL = `${config.url}`;
const VIDEO_URI = '/videos';

@Injectable({ providedIn: 'root' })
export class VideoService {
  constructor(private http: HttpClient) { }

  getVideosByCategoryId(id: number) {
    console.log (config.url);
    return this.http.get<ResponseObject<Video[]>>(`${API_URL}${VIDEO_URI}?categoryId=${id}`);
  }
}
