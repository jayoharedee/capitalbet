import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RiskStatementComponent } from './risk-statement.component';

describe('RiskStatementComponent', () => {
  let component: RiskStatementComponent;
  let fixture: ComponentFixture<RiskStatementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RiskStatementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RiskStatementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
