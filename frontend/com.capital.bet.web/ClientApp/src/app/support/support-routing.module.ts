import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SupportComponent } from './support.component';
import { SupportDashboardComponent } from './support-dashboard/support-dashboard.component';
import { PathNotFoundComponent } from '../shared/path-not-found/path-not-found.component';

const routes: Routes = [
  {
    path: '', component: SupportComponent,
    children: [
      { path: 'dashboard', component: SupportDashboardComponent },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: '**', component: PathNotFoundComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupportRoutingModule { }
