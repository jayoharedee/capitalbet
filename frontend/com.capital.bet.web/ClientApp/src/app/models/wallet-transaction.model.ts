

/** Wallet Transactions Model */
export class WalletTransaction {
  public transationId: string;
  public accountId: string;
  public typeId: number;
  public amount: number;
  public note: string;
  public createdBy: string;
  public updatedBy: string;
  public updatedDate: Date;
  public createdDate: Date;
}
