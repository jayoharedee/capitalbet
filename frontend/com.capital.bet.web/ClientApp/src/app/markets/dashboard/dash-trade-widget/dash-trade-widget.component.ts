import { Component, OnInit, Input, ViewEncapsulation, OnDestroy } from '@angular/core';
import { TradeSettings } from '../../models/trade-settings.model';
import * as Highcharts from 'highcharts';
import HC_stock from 'highcharts/modules/stock';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { StockType } from '../../../models/stock-type.model';
import { StocksService } from '../../../services/stocks.service';
import { StockRate } from '../../../models/stock-rate.mode';
import { release } from 'os';
import { ActiveTrade } from '../../models/active-trade.model';
import { AccountService } from '../../../services/account.service';
import { WalletService } from '../../../services/wallet.service';
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
  activeTrade: ActiveTrade = null;
  userBalance: number = 0;
  potentialEarning: number = 0;
  earningRate: number = 0;
  betGroup: FormGroup;

  public chartType: string = 'line';

  public chartDatasets: Array<any> = [
    { data: [0], label: 'Rate' },
    { data: [0], label: 'Bid' },
    { data: [0], label: 'Ask' },
    { data: [0], label: 'Open' },
    { data: [0], label: 'Close' },
    { data: [0], label: 'High' },
    { data: [0], label: 'Low' }
  ];
  public chartLabels: Array<any> = [];

  public chartColors: Array<any> = [
    {
      backgroundColor: 'rgba(105, 0, 132, .2)',
      borderColor: 'rgba(200, 99, 132, .7)',
      borderWidth: 2,
    },
    {
      backgroundColor: 'rgba(0, 137, 132, .2)',
      borderColor: 'rgba(0, 10, 130, .7)',
      borderWidth: 2,
    }
  ];


  public chartOptions: any = {
    responsive: true
  };
  public chartClicked(e: any): void { }
  public chartHovered(e: any): void { }

  public selectedCurrency: StockType = null;

  subs: Subscription[] = [];
  rate: number[] = [];
  bid: number[] = [];
  ask: number[] = [];
  open: number[] = [];
  close: number[] = [];
  high: number[] = [];
  low: number[] = [];
  labels: string[] = [];

  get Currency() { return this.betGroup.get('currency'); }
  get Amount() { return this.betGroup.get('amount'); }
  get Period() { return this.betGroup.get('period'); }

  constructor(private stockSrv: StocksService,
    private accSrv: AccountService,
    private walletSrv: WalletService,
    private fb: FormBuilder) {
    this.betGroup = this.fb.group({
      currency: ['0'],
      amount: ['0'],
      period: ['2']
    });
  }


  ngOnInit(): void {

    this.subs.push(
      this.Amount.valueChanges.subscribe((value) => {
        if ((+value) > this.userBalance) {
          this.Amount.setValue(this.userBalance);
          this.potentialEarning = ((this.userBalance) * this.earningRate);
        } else {
          this.potentialEarning = ((+value) * this.earningRate);
        }
      })
    );

    this.subs.push(
      this.walletSrv.getUserBalance().subscribe((result: any) => {
        this.userBalance = result.balance;
      })
    );

    this.subs.push(
      this.stockSrv.StockRatesChanged.subscribe((stocks) => {
        if (this.config != null && this.config.currency.length > 2) {
          var data = stocks.filter((a) => {
            return (a.currency == this.config.currency) ? true : false;
          });

          this.rate.push(data[0].rate);
          this.bid.push(data[0].bid);
          this.ask.push(data[0].ask);
          this.open.push(data[0].open);
          this.close.push(data[0].close);
          this.high.push(data[0].high);
          this.low.push(data[0].low);

          this.chartDatasets = [
            { data: this.rate, label: 'Rate' },
            { data: this.bid, label: 'Bid' },
            { data: this.ask, label: 'Ask' },
            { data: this.open, label: 'Open' },
            { data: this.close, label: 'Close' },
            { data: this.high, label: 'High' },
            { data: this.low, label: 'Low' }
          ]
          let dt: Date = new Date(data[0].timestamp);
          this.labels.push(dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds());
          this.chartLabels = this.labels;

        }
      })
    );
    this.stockSrv.startConnection();

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

  /** Compute any Period or modifier biases */
  get computePeriodBias(): number {
    return 0;
  }


  /**
   * load the currency (stock) data
   * @param id Stock / Currecny Id
   */
  private loadCurrency(id: string) {
    this.subs.push(
      this.stockSrv.getStockById(id).subscribe((stock: StockType) => {
        this.selectedCurrency = stock;
        this.earningRate = (stock.payOutRate + this.computePeriodBias);
        this.potentialEarning = ((+this.Amount.value) * this.earningRate);
      })
    );
  }

  /**
   *  On Amount Changed
   * @param value New Amount
   */
  onamountChnaged(value) {
    
  }


  currencyChaged(result) {
    this.config = {
      currency: result
    };
    this.loadCurrency(result);
    this.rate = [];
    this.bid = [];
    this.ask = [];
    this.open = [];
    this.close = [];
    this.high = [];
    this.low = [];
    this.labels = [];
    this.chartDatasets = [];
    this.chartLabels = [];

  }

}
