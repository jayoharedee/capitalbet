import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SupportRoutingModule } from './support-routing.module';
import { SupportComponent } from './support.component';
import { SupportDashboardComponent } from './support-dashboard/support-dashboard.component';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [SupportComponent, SupportDashboardComponent],
  imports: [
    CommonModule,
    SharedModule.forRoot(),
    SupportRoutingModule
  ]
})
export class SupportModule { }
