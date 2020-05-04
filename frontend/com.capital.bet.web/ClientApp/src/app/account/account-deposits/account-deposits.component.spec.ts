import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountDepositsComponent } from './account-deposits.component';

describe('AccountDepositsComponent', () => {
  let component: AccountDepositsComponent;
  let fixture: ComponentFixture<AccountDepositsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountDepositsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountDepositsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
