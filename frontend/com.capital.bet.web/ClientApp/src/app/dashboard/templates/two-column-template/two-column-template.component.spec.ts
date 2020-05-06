import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoColumnTemplateComponent } from './two-column-template.component';

describe('TwoColumnTemplateComponent', () => {
  let component: TwoColumnTemplateComponent;
  let fixture: ComponentFixture<TwoColumnTemplateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwoColumnTemplateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoColumnTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
