/** Application User Model */
export class ApplicationUser {
  public friendlyName: string;
  public fullName: string;
  public isEnabled: boolean;
  public firstName: string;
  public lastName: string;
  public createdBy: string;
  public updatedBy: string;
  public updatedDate: Date;
  public createdDate: Date;
  public projectMaxCount: number;
  public maxFileCount: number;
  public maxFileSize: number;
  public diskSpace: number;
  public diskSpaceUsed: number;
  public id: string;
  public userName: string;
  public normalizedUserName: string;
  public email: string;
  public normalizedEmail: string;
  public emailConfirmed: boolean;
  public phoneNumber: string;
  public phoneNumberConfirmed: boolean;
  public twoFactorEnabled: boolean;
  public lockoutEnd: Date;
  public lockoutEnabled: boolean;
  public accessFailedCount: number;
  public profileImage: string;
}
