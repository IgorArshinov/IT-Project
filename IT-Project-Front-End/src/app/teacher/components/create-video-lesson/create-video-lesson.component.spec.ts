import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateVideoLessonComponent } from './create-video-lesson.component';

describe('CreateVideoLessonComponent', () => {
  let component: CreateVideoLessonComponent;
  let fixture: ComponentFixture<CreateVideoLessonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateVideoLessonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateVideoLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
