import { Component, OnInit, OnDestroy } from '@angular/core';
import { WalletService } from '../../../services/wallet.service';
import { Subscription } from 'rxjs';
import { WalletTransaction } from '../../../models/wallet-transaction.model';

@Component({
  selector: 'app-dash-wallet',
  templateUrl: './dash-wallet.component.html',
  styleUrls: ['./dash-wallet.component.scss']
})
export class DashWalletComponent implements OnInit, OnDestroy{

  currentBalance: number = 0;
  transactions: WalletTransaction[] = [];
  transactionsLoading: boolean = false;
  subs: Subscription[] = [];

  constructor(private walletSrv: WalletService) { }
    

  ngOnInit(): void {
    this.transactionsLoading = true;
    this.subs.push(
      this.walletSrv.getUserWalletTransactions().subscribe((trs: WalletTransaction[]) => {
        this.transactions = trs;
        this.transactionsLoading = false;
      })
    );

    this.subs.push(
      this.walletSrv.getUserBalance().subscribe((result: any) => {
        this.currentBalance = result.balance;
      })
    );
  }

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

}
