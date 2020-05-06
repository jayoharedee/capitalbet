import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashTitleEditorComponent } from './dash-title-editor.component';

describe('DashTitleEditorComponent', () => {
  let component: DashTitleEditorComponent;
  let fixture: ComponentFixture<DashTitleEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashTitleEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashTitleEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
