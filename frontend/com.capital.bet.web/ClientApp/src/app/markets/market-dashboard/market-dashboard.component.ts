import { Component, OnInit } from '@angular/core';
import { DashboardItem } from '../../dashboard/models/dashboard-item.model';
import { DashboardConfig } from '../../dashboard/models/dashboard-config.model';
import { TwoColumnTemplateComponent } from '../../dashboard/templates/two-column-template/two-column-template.component';
import { DashWalletComponent } from '../dashboard/dash-wallet/dash-wallet.component';
import { DashNotifyWidgetComponent } from '../dashboard/dash-notify-widget/dash-notify-widget.component';
import { DashTradeWidgetComponent } from '../dashboard/dash-trade-widget/dash-trade-widget.component';
import { TradeSettingsComponent } from '../dashboard/dash-trade-widget/trade-settings.component';

@Component({
  selector: 'app-market-dashboard',
  templateUrl: './market-dashboard.component.html',
  styleUrls: ['./market-dashboard.component.scss']
})
export class MarketDashboardComponent implements OnInit {

  dashItems: DashboardItem[] = [
    {
      id: 'wallet',
      component: DashWalletComponent,
      config: null,
      order: 0,
      settingsDialog: null,
      title:'Wallet'
    },
    {
      id: 'trades',
      component: DashTradeWidgetComponent,
      config: null,
      order: 0,
      settingsDialog: TradeSettingsComponent,
      title: 'Trade Widget'
    },
    {
      id: 'notify',
      component: DashNotifyWidgetComponent,
      config: null,
      order: 0,
      settingsDialog: null,
      title: 'Notifications'
    }
  ];
  dashConfig: DashboardConfig = {
    dashId: '',
    dashName: 'Default Dashboard',
    dashNote: 'Default Dashboard',
    dashTemplate: {
      template: TwoColumnTemplateComponent,
      title: 'TwoColumnTemplateComponent',
      zoneItems: [
        [
          {
            id: 'trades',
            component: DashTradeWidgetComponent,
            config: null,
            order: 0,
            settingsDialog: TradeSettingsComponent,
            title: 'Trade Widget'
          }
        ],
        [
          {
            id: 'wallet',
            component: DashWalletComponent,
            config: null,
            order: 0,
            settingsDialog: null,
            title: 'Wallet'
          },
          {
            id: 'notify',
            component: DashNotifyWidgetComponent,
            config: null,
            order: 0,
            settingsDialog: null,
            title: 'Notifications'
          }
        ]
      ],
      zonesCount: 2
    },
    userId: ''
  };

  constructor() { }

  ngOnInit(): void {
  }

}
