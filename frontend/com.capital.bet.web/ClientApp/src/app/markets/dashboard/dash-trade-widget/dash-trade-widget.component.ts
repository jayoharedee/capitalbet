import { Component, OnInit, Input, ViewEncapsulation, OnDestroy } from '@angular/core';
import { TradeSettings } from '../../models/trade-settings.model';
import * as Highcharts from 'highcharts';
import HC_stock from 'highcharts/modules/stock';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { StockType } from '../../../models/stock-type.model';
import { StocksService } from '../../../services/stocks.service';
HC_stock(Highcharts);

@Component({
  selector: 'app-dash-trade-widget',
  templateUrl: './dash-trade-widget.component.html',
  styleUrls: ['./dash-trade-widget.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DashTradeWidgetComponent implements OnInit, OnDestroy {


  @Input() config: TradeSettings;

  stockTypes: StockType[] = [];

  betGroup: FormGroup;

  highcharts = Highcharts;
  chartOptions = {
    chart: {
      type: "spline"
    },
    title: {
      text: "Monthly Average Temperature"
    },
    subtitle: {
      text: "Source: WorldClimate.com"
    },
    xAxis: {
      categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    yAxis: {
      title: {
        text: "Temperature °C"
      }
    },
    tooltip: {
      valueSuffix: " °C"
    },
    series: [
      {
        name: 'Tokyo',
        data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
      },
      {
        name: 'New York',
        data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]
      },
      {
        name: 'Berlin',
        data: [-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0]
      },
      {
        name: 'London',
        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
      }
    ]
  };

  subs: Subscription[] = [];

  constructor(private stockSrv: StocksService,
    private fb: FormBuilder)
  {
    this.betGroup = this.fb.group({
      currency:[0],
      amount: [0],
      period: [2],
    });
  }
    

  ngOnInit(): void {
    if (this.config != null) {
      console.log(this.config);
    }

    this.subs.push(
      this.stockSrv.getStockTypes().subscribe((stks: StockType[]) => {
        this.stockTypes = stks;
      })
    );

  }


  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

}
