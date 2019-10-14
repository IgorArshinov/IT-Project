import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConversationCategoriesComponent } from './conversation-categories.component';

describe('ConversationCategoriesComponent', () => {
  let component: ConversationCategoriesComponent;
  let fixture: ComponentFixture<ConversationCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConversationCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConversationCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should createExerciseSeries', () => {
    expect(component).toBeTruthy();
  });
});
