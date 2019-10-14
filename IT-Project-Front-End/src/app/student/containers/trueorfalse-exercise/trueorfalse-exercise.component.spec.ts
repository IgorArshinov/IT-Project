import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrueorfalseExerciseComponent } from './trueorfalse-exercise.component';

describe('TrueorfalseExerciseComponent', () => {
  let component: TrueorfalseExerciseComponent;
  let fixture: ComponentFixture<TrueorfalseExerciseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrueorfalseExerciseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrueorfalseExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
