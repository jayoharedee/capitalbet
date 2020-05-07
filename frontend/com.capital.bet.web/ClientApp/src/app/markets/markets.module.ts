import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MarketsRoutingModule } from './markets-routing.module';
import { MarketsComponent } from './markets.component';
import { MarketDashboardComponent } from './market-dashboard/market-dashboard.component';
import { SharedModule } from '../shared.module';
import { DashboardModule } from '../dashboard/dashboard.module';
import { DashWalletComponent } from './dashboard/dash-wallet/dash-wallet.component';
import { DashTradeWidgetComponent } from './dashboard/dash-trade-widget/dash-trade-widget.component';
import { DashNotifyWidgetComponent } from './dashboard/dash-notify-widget/dash-notify-widget.component';
import { TradeSettingsComponent } from './dashboard/dash-trade-widget/trade-settings.component';
import { MDBBootstrapModule, MDBSpinningPreloader } from 'ng-uikit-pro-standard';
import { ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptor } from '../services/token-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { HighchartsChartModule } from 'highcharts-angular';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    MarketsComponent,
    MarketDashboardComponent,
    DashWalletComponent,
    DashTradeWidgetComponent,
    DashNotifyWidgetComponent,
    TradeSettingsComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HighchartsChartModule,
    RouterModule,
    DashboardModule,
    SharedModule.forRoot(),
    MDBBootstrapModule.forRoot(),
    MarketsRoutingModule
  ],
  entryComponents: [
    DashWalletComponent,
    DashTradeWidgetComponent,
    DashNotifyWidgetComponent,
    TradeSettingsComponent
  ],
  providers: [
    MDBSpinningPreloader,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ]
})
export class MarketsModule { }
