/** Application User Model */
export class ApplicationUser {
  public isEnabled: boolean;
  public accountId: string;
  public createdBy: string;
  public updatedBy: string;
  public updatedDate: Date;
  public createdDate: Date;
  public firstName: string;
  public lastName: string;
  public mobileNumber: string;
  public profileImage: string;
  public id: string;
  public userName: string;
  public normalizedUserName: string;
  public email: string;
  public normalizedEmail: string;
  public emailConfirmed: true;
  public phoneNumber: string;
  public phoneNumberConfirmed: boolean;
  public twoFactorEnabled: boolean;
  public lockoutEnd: Date;
  public lockoutEnabled: boolean;
  public accessFailedCount: number;
}
