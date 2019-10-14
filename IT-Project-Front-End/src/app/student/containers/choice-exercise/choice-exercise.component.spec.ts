import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoiceExerciseComponent } from './choice-exercise.component';

describe('ChoiceExerciseComponent', () => {
  let component: ChoiceExerciseComponent;
  let fixture: ComponentFixture<ChoiceExerciseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChoiceExerciseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChoiceExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
