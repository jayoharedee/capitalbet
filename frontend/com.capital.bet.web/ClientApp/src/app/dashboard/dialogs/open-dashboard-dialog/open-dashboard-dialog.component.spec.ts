import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenDashboardDialogComponent } from './open-dashboard-dialog.component';

describe('OpenDashboardDialogComponent', () => {
  let component: OpenDashboardDialogComponent;
  let fixture: ComponentFixture<OpenDashboardDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenDashboardDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenDashboardDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
