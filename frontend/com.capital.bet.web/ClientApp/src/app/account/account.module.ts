import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { MyWalletComponent } from './my-wallet/my-wallet.component';
import { AccountDepositsComponent } from './account-deposits/account-deposits.component';
import { AccountDashboardComponent } from './account-dashboard/account-dashboard.component';
import { AccountTransfersComponent } from './account-transfers/account-transfers.component';
import { SharedModule } from '../shared.module';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from '../services/token-interceptor';
import { AccountWithdrawComponent } from './account-withdraw/account-withdraw.component';


@NgModule({
  declarations: [
    AccountComponent,
    MyWalletComponent,
    AccountDepositsComponent,
    AccountDashboardComponent,
    AccountTransfersComponent,
    AccountWithdrawComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule.forRoot(),
    MDBBootstrapModulesPro.forRoot(),
    AccountRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
})
export class AccountModule { }
