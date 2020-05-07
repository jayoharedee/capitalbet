import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import * as signalR from "@aspnet/signalr";
import { StockRate } from '../models/stock-rate.mode';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StocksService {
  private _connection: signalR.HubConnection;

  private _isConnected: boolean = false;
  /** Is Hub Connected */
  public get Connected() { return this._isConnected; }

  private _stockRateSub: Subject<StockRate[]> = new Subject();

  /** Stock rate feed observable */
  public get StockRatesChanged(): Observable<StockRate[]> {
    return this._stockRateSub.asObservable();
  }

  constructor(private http: HttpClient,
    private config: ConfigService) {

  }

  /** Connect to the stock hub service */
  public startConnection() {
    if (!this._isConnected) {
      this._connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5000/stocks')
        .build();

      this._connection.start()
        .then(() => {
          console.log('Stock Hub Connected ...');
          this._isConnected = true;
          this.listenForStockChanges();
        })
        .catch(err => console.log('Error while starting Stock Hub =>', err));
    }
  }

  /** Stop the stock hub service */
  public stopConnection() {
    if (this._isConnected) {
      this._connection.stop().then(() => {
        console.log('Stock Hub Stopped ....');
        this._isConnected = false;
      }).catch(err => console.log('Error while stopping Stock Hub =>', err));
    }
  }


  private listenForStockChanges() {
    this._connection.on('stocks', (data: StockRate[]) => {
      this._stockRateSub.next(data);
    });
  }


  /** Get the supported stock types */
  public getStockTypes() {
    let url: string = this.config.ApiUrl + '/api/Stocks/types';
    return this.http.get(url);
  }

  /**
   *  get Stock By Id
   * @param id Stock Id
   */
  public getStockById(id: string) {
    let url: string = this.config.ApiUrl + '/api/Stocks/stock/'+id;
    return this.http.get(url);
  }


}
