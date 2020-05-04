import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MarketsComponent } from './markets.component';
import { MarketDashboardComponent } from './market-dashboard/market-dashboard.component';
import { PathNotFoundComponent } from '../shared/path-not-found/path-not-found.component';
import { AuthGuardService } from '../services/auth-guard.service';

const routes: Routes = [
  {
    path: '', component: MarketsComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'dashboard', component: MarketDashboardComponent, canActivate: [AuthGuardService] },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: '**', component: PathNotFoundComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MarketsRoutingModule { }
