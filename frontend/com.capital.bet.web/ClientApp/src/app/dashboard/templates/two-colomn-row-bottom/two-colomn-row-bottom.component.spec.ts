import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoColomnRowBottomComponent } from './two-colomn-row-bottom.component';

describe('TwoColomnRowBottomComponent', () => {
  let component: TwoColomnRowBottomComponent;
  let fixture: ComponentFixture<TwoColomnRowBottomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwoColomnRowBottomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoColomnRowBottomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
