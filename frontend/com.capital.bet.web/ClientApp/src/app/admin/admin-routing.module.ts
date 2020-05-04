import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { PathNotFoundComponent } from '../shared/path-not-found/path-not-found.component';
import { AuthGuardService } from '../services/auth-guard.service';

const routes: Routes = [
  {
    path: '', component: AdminComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'dashboard', component: AdminDashboardComponent, canActivate: [AuthGuardService] },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: '**', component: PathNotFoundComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
