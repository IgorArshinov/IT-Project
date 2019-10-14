import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavNextComponent } from './nav-next.component';

describe('NavNextComponent', () => {
  let component: NavNextComponent;
  let fixture: ComponentFixture<NavNextComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavNextComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavNextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
