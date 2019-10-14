import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrueorfalseItemComponent } from './trueorfalse-item.component';

describe('TrueorfalseItemComponent', () => {
  let component: TrueorfalseItemComponent;
  let fixture: ComponentFixture<TrueorfalseItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrueorfalseItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrueorfalseItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
