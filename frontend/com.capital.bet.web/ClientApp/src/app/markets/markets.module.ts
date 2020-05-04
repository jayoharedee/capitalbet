import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MarketsRoutingModule } from './markets-routing.module';
import { MarketsComponent } from './markets.component';
import { MarketDashboardComponent } from './market-dashboard/market-dashboard.component';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [MarketsComponent, MarketDashboardComponent],
  imports: [
    CommonModule,
    SharedModule.forRoot(),
    MarketsRoutingModule
  ]
})
export class MarketsModule { }
