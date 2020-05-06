import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashTradeWidgetComponent } from './dash-trade-widget.component';

describe('DashTradeWidgetComponent', () => {
  let component: DashTradeWidgetComponent;
  let fixture: ComponentFixture<DashTradeWidgetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashTradeWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashTradeWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
