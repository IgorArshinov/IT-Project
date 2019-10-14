import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AudioCategoriesComponent } from './audio-categories.component';

describe('AudioCategoriesComponent', () => {
  let component: AudioCategoriesComponent;
  let fixture: ComponentFixture<AudioCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AudioCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AudioCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
