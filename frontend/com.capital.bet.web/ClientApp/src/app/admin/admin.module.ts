import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [
    AdminComponent,
    AdminDashboardComponent, 
  ],
  imports: [
    CommonModule,
    SharedModule.forRoot(),
    AdminRoutingModule
  ]
})
export class AdminModule { }
