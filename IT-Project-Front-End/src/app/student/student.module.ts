import {EffectsModule} from '@ngrx/effects';
import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {StoreModule} from '@ngrx/store';

import {StudentRoutingModule} from './student-routing.module';
import {containers} from './containers';
import {components} from './components';
import {reducers} from './store/reducers';
import {effects} from './store/effects';
import {SharedModule} from '../shared/shared.module';
import { ExerciseSeriesComponent } from './containers/exercise-series/exercise-series.component';

@NgModule({
  declarations: [...containers, ...components, ExerciseSeriesComponent],
  imports: [
    CommonModule,
    SharedModule,
    StudentRoutingModule,
    StoreModule.forFeature('student', reducers),
    EffectsModule.forFeature(effects),
  ],
})
export class StudentModule {
}
