import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveDashDialogComponent } from './save-dash-dialog.component';

describe('SaveDashDialogComponent', () => {
  let component: SaveDashDialogComponent;
  let fixture: ComponentFixture<SaveDashDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaveDashDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveDashDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
