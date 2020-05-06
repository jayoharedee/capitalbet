import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashNotifyWidgetComponent } from './dash-notify-widget.component';

describe('DashNotifyWidgetComponent', () => {
  let component: DashNotifyWidgetComponent;
  let fixture: ComponentFixture<DashNotifyWidgetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashNotifyWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashNotifyWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
