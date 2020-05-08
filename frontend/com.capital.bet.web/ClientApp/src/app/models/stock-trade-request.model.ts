
/** Stock Trade Request */
export class StockTradeRequest {
  public requestDate: Date;
  public period: number;
  public amount: number;
  public isHigh: boolean;
  public currency: string;
}
