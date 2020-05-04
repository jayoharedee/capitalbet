import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountComponent } from './account.component';
import { AccountDashboardComponent } from './account-dashboard/account-dashboard.component';
import { AccountDepositsComponent } from './account-deposits/account-deposits.component';
import { MyWalletComponent } from './my-wallet/my-wallet.component';
import { AccountTransfersComponent } from './account-transfers/account-transfers.component';
import { PathNotFoundComponent } from '../shared/path-not-found/path-not-found.component';
import { AuthGuardService } from '../services/auth-guard.service';

const routes: Routes = [
  {
    path: '', component: AccountComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'dashboard', component: AccountDashboardComponent, canActivate: [AuthGuardService] },
      { path: 'deposit', component: AccountDepositsComponent, canActivate: [AuthGuardService] },
      { path: 'mywallet', component: MyWalletComponent, canActivate: [AuthGuardService] },
      { path: 'transfers', component: AccountTransfersComponent, canActivate: [AuthGuardService] },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: '**', component: PathNotFoundComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
