import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TradeSettingsComponent } from './trade-settings.component';

describe('TradeSettingsComponent', () => {
  let component: TradeSettingsComponent;
  let fixture: ComponentFixture<TradeSettingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TradeSettingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TradeSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
