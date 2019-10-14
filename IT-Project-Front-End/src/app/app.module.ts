import { InMemoryDataService } from './in-memory-data.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { RouterStateSerializer, StoreRouterConnectingModule } from '@ngrx/router-store';
import { EffectsModule } from '@ngrx/effects';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from '../environments/environment';
import { effects, reducers } from './store';
import { CustomSerializer } from './store/reducers/custom-route-serializer';

import { JwtModule } from '@auth0/angular-jwt';
import { DragDropModule } from '@angular/cdk/drag-drop';

import * as fromComponents from './root-components';

import { MaterialModule } from './material.module';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatSelectModule } from '@angular/material';
import { FakeAuthInterceptor } from './teacher/interceptors/fake-auth.interceptor';
import { JwtInterceptor } from './teacher/interceptors/jwt.interceptor';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CreateVideoLessonComponent } from './teacher/components';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { CreateExerciseSeriesComponent } from './teacher/containers';
import { TeacherModule } from './teacher/teacher.module';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

const providers: Provider = [
  { provide: RouterStateSerializer, useClass: CustomSerializer },
  { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
  // { provide: HTTP_INTERCEPTORS, useClass: FakeAuthInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  { provide: LocationStrategy, useClass: HashLocationStrategy },
];

const imports = [
  AppRoutingModule,
  BrowserAnimationsModule,
  BrowserModule,
  DragDropModule,
  EffectsModule.forRoot(effects),
  FontAwesomeModule,
  HttpClientModule,
  JwtModule.forRoot({ config: { tokenGetter: tokenGetter, }, }),
  MatSelectModule,
  MaterialModule,
  ReactiveFormsModule,
  StoreModule.forRoot(reducers),
  StoreRouterConnectingModule,
  StoreDevtoolsModule.instrument({ name: 'Limino', logOnly: environment.production, }),
  TeacherModule,
];

// if (!environment.production) {
//   imports.push(HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, { delay: 500, dataEncapsulation: true, passThruUnknownUrl: true }));
// }

// if (!environment.production) {
//   providers.push({ provide: HTTP_INTERCEPTORS, useClass: FakeAuthInterceptor, multi: true },
//   );
// }

@NgModule({
  declarations: [AppComponent, ...fromComponents.components],
  entryComponents: [fromComponents.PopupComponent, fromComponents.ChoicesComponent, CreateVideoLessonComponent, fromComponents.ConfirmationDialogComponent, CreateExerciseSeriesComponent,],
  imports: [ imports ],
  providers: [ providers, ],
  bootstrap: [AppComponent],
  exports: [],
})

export class AppModule {
}
