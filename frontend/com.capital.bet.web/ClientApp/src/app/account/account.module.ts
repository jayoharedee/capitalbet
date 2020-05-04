import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { MyWalletComponent } from './my-wallet/my-wallet.component';
import { AccountDepositsComponent } from './account-deposits/account-deposits.component';
import { AccountDashboardComponent } from './account-dashboard/account-dashboard.component';
import { AccountTransfersComponent } from './account-transfers/account-transfers.component';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [
    AccountComponent,
    MyWalletComponent,
    AccountDepositsComponent,
    AccountDashboardComponent,
    AccountTransfersComponent
  ],
  imports: [
    CommonModule,
    SharedModule.forRoot(),
    AccountRoutingModule
  ]
})
export class AccountModule { }
