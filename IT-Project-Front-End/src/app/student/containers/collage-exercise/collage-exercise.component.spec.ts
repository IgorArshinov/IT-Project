import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollageExerciseComponent } from './collage-exercise.component';

describe('CollageExerciseComponent', () => {
  let component: CollageExerciseComponent;
  let fixture: ComponentFixture<CollageExerciseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollageExerciseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollageExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
