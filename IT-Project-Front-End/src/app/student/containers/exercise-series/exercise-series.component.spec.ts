import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseSeriesComponent } from './exercise-series.component';

describe('ExerciseSeriesComponent', () => {
  let component: ExerciseSeriesComponent;
  let fixture: ComponentFixture<ExerciseSeriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseSeriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseSeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
