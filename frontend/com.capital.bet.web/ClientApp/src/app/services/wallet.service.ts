import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  constructor(private http: HttpClient,
    private config: ConfigService) { }


  /** Get User Wallet Transactions */
  public getUserWalletTransactions() {
    let url: string = this.config.ApiUrl + '/api/Wallet/transactions';
    return this.http.get(url);
  }

  /** Get User Balance */
  public getUserBalance() {
    let url: string = this.config.ApiUrl + '/api/Wallet/balance';
    return this.http.get(url);
  }

  /** Get User Last Deposit */
  public getUserLastDeposit() {
    let url: string = this.config.ApiUrl + '/api/Wallet/last/deposit';
    return this.http.get(url);
  }

  /** Get User Total Deposit */
  public getUserTotalDeposit() {
    let url: string = this.config.ApiUrl + '/api/Wallet/total/deposit';
    return this.http.get(url);
  }

}
