import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class StocksService {

  constructor(private http: HttpClient,
    private config: ConfigService) { }

  /** Get the supported stock types */
  public getStockTypes() {
    let url: string = this.config.ApiUrl + '/api/Stocks/types';
    return this.http.get(url);
  }

}
