import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollageItemComponent } from './collage-item.component';

describe('CollageItemComponent', () => {
  let component: CollageItemComponent;
  let fixture: ComponentFixture<CollageItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollageItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollageItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
