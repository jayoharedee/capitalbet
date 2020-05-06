import { Component, OnInit, OnDestroy } from '@angular/core';
import { WalletService } from '../../services/wallet.service';
import { WalletTransaction } from '../../models/wallet-transaction.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-my-wallet',
  templateUrl: './my-wallet.component.html',
  styleUrls: ['./my-wallet.component.scss']
})
export class MyWalletComponent implements OnInit, OnDestroy {

  currentBalance: number = 0;
  lastDeposit: number = 0;
  totalDeposits: number = 0;


  transactions: WalletTransaction[] = [];

  subs: Subscription[] = [];

  constructor(private walletSrv: WalletService) { }
    

  ngOnInit(): void {
    this.subs = [];
    this.subs.push(
      this.walletSrv.getUserWalletTransactions().subscribe((result: WalletTransaction[]) => {
        this.transactions = result;
      })
    );

    this.subs.push(
      this.walletSrv.getUserBalance().subscribe((result: any) => {
        this.currentBalance = result.balance;
      })
    );

    this.subs.push(
      this.walletSrv.getUserLastDeposit().subscribe((result: WalletTransaction) => {
        this.lastDeposit = result.amount;
      })
    );

    this.subs.push(
      this.walletSrv.getUserTotalDeposit().subscribe((result:any) => {
        this.totalDeposits = result.balance;
      })
    );
  }


  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

}
