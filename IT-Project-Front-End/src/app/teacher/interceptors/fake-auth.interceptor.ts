import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { delay, mergeMap, materialize, dematerialize } from 'rxjs/operators';

@Injectable()
export class FakeAuthInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const authHeader = request.headers.get('Authorization');
    const isLoggedIn = authHeader && authHeader.startsWith('Bearer fake-jwt-token');

    return of(null).pipe(mergeMap(() => {
      if (request.url.endsWith('authenticate') && request.method === 'POST') {
        console.log(request.body.data.username);
        console.log(request.body.data.password);

        if (request.body.data.username !== "test@test.be" && request.body.data.password !== "password") return error('Username or password is incorrect');
        return ok({data: {
          id: 1,
          username: "test@test.be",
          password: "password",
          token: `fake-jwt-token`
        }});
      }
      if (request.url.endsWith('auth/register') && request.method === 'POST'){
        return empty();
      }

      if (request.url.endsWith('upload') && request.method === 'POST'){
        return created( {data: {
          id: 1,
          path: 'appel.jpg'
        }});
      }

      return next.handle(request);
    }))
    // call materialize and dematerialize to ensure delay even if an error is thrown (https://github.com/Reactive-Extensions/RxJS/issues/648)
      .pipe(materialize())
      .pipe(delay(500))
      .pipe(dematerialize());

    // private helper functions

    function ok(body) {
      return of(new HttpResponse({ status: 200, body }));
    }

    function created(body){
      return of(new HttpResponse({ status: 201, body }));
    }

    function empty() {
      return of(new HttpResponse({ status: 204}))
    }

    function unauthorised() {
      return throwError({ status: 401, error: { message: 'Unauthorised' } });
    }

    function error(message) {
      return throwError({ status: 400, error: { message } });
    }
  }

}
