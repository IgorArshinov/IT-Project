import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoiceItemComponent } from './choice-item.component';

describe('ChoiceItemComponent', () => {
  let component: ChoiceItemComponent;
  let fixture: ComponentFixture<ChoiceItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChoiceItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChoiceItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
