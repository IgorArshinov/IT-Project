import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

import config from '../../api_config'

const API_URL = `${config.url}`;

const API_URL_LOGIN = `${API_URL}/users/authenticate`;
const API_URL_REGISTER = `${API_URL}/users/register`;

@Injectable({
  providedIn: 'root',
})
export class JwtService {

  constructor(private http: HttpClient) {
  }

  public get loggedIn(): boolean{
    return this.token !==  null;
  }

  public get token(): string {
    return localStorage.getItem('access_token');
  }

  login(email: string, password: string) {
    return this.http.post<{data: { id: number, username: string, token: string } }>(API_URL_LOGIN, {
      data: {
        username: email,
        password: password,
      }
    }).pipe(tap(res => {
      localStorage.setItem('access_token', res.data.token);
    }));

  }

  register(email: string, password: string) {
    return this.http.post<{}>(API_URL_REGISTER, { email, password }).pipe(tap(res => {

    }));
  }

  logout() {
    localStorage.removeItem('access_token');
  }

}



