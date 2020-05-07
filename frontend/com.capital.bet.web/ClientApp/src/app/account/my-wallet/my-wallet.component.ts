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

  transactionsLoading: boolean = false;


  transactions: WalletTransaction[] = [];

  subs: Subscription[] = [];

  constructor(private walletSrv: WalletService) { }
    

  ngOnInit(): void {
    this.subs = [];
    this.transactionsLoading = true;
    this.subs.push(
      this.walletSrv.getUserWalletTransactions().subscribe((result: WalletTransaction[]) => {
        this.transactions = result;
        this.transactionsLoading = false;
      })
    );

    this.subs.push(
      this.walletSrv.getUserBalance().subscribe((result: any) => {
        try {
          this.currentBalance = result.balance;
        } catch{
          this.currentBalance = -1;
        }
      })
    );

    this.subs.push(
      this.walletSrv.getUserLastDeposit().subscribe((result: WalletTransaction) => {
        try {
          this.lastDeposit = result.amount;
        } catch{
          this.lastDeposit = -1;
        }
      })
    );

    this.subs.push(
      this.walletSrv.getUserTotalDeposit().subscribe((result: any) => {
        try {
          this.totalDeposits = result.balance;
        } catch{
          this.totalDeposits = -1;
        }
      })
    );
  }


  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }

}
