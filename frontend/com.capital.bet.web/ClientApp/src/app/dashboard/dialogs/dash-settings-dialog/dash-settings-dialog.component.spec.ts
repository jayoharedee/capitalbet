import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashSettingsDialogComponent } from './dash-settings-dialog.component';

describe('DashSettingsDialogComponent', () => {
  let component: DashSettingsDialogComponent;
  let fixture: ComponentFixture<DashSettingsDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashSettingsDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashSettingsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
