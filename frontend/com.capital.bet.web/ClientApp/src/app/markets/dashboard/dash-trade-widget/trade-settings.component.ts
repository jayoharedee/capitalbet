import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { DashboardItem } from '../../../dashboard/models/dashboard-item.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { TradeSettings } from '../../models/trade-settings.model';
import { StocksService } from '../../../services/stocks.service';
import { StockType } from '../../../models/stock-type.model';

@Component({
  selector: 'app-trade-settings',
  templateUrl: './trade-settings.component.html',
  styleUrls: ['./trade-settings.component.scss']
})
export class TradeSettingsComponent implements OnInit, OnDestroy {

  config: DashboardItem;
  dataUpdated: Subject<DashboardItem> = new Subject();
  compCfg: TradeSettings;
  currencyOptions: Array<any> = [];

  updateGroup: FormGroup;

  subs: Subscription[] = [];

  get Title() { return this.updateGroup.get('title'); }
  get Currency() { return this.updateGroup.get('cur'); }

  constructor(public modalRef: MDBModalRef,
    private stockSrv: StocksService,
    private fb: FormBuilder) {
    this.updateGroup = this.fb.group({
      title: ['', [Validators.required]],
      cur: ['', [Validators.required]]
    })
  }


  ngOnInit(): void {
    this.subs = [];
    this.compCfg = this.config.config;
    this.Title.setValue(this.config.title);
    if (this.compCfg != null && this.compCfg.currency != null)
      this.Currency.setValue(this.compCfg.currency);

    this.subs.push(
      this.stockSrv.getStockTypes().subscribe((result: StockType[]) => {
        for (let itm of result) {
          this.currencyOptions.push({ value: itm.stockId, label: itm.name });
        }
      })
    );
  }

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

  updateTitle() {
    this.config.title = this.Title.value;
    let trd: TradeSettings = { currency: this.Currency.value };
    this.compCfg = trd;
    this.config.config = this.compCfg;
    this.dataUpdated.next(this.config);
  }

}
