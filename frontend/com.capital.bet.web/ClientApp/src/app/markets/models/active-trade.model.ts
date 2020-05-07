
/** Active Trade Marker */
export class ActiveTrade {
  public currency: string;
  public period: number;
  public amount: number;
  public stockPrice: number;
  public finialPrice: number;
  public isBuy: boolean;
  public premium: number;
  public timeSet: Date;
}
