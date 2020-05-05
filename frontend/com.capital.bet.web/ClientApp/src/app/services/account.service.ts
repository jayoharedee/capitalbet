import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApplicationUser } from '../models/application-user.model';
import { ConfigService } from './config.service';
import { AuthService } from './auth.service';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient,
    private config: ConfigService) { }

  /**
   *  Register User
   * @param user Application User
   * @param password User Password
   */
  public registerUser(user: ApplicationUser, password: string, deposit: number, accountType:string) {
    let url: string = this.config.ApiUrl + '/api/Account/users/create';
    return this.http.post(url, { user: user, password: password, depositAmount: deposit, accountType: accountType });
  }

  /** Get the current logged in user */
  public getCurrentUser() {
    let url: string = this.config.ApiUrl + '/api/Account/users/current';
    return this.http.get(url);
  }

  /**
   *  Check Username
   * @param username Username
   */
  public checkUsername(username: string) {
    let url: string = this.config.ApiUrl + '/api/Account/checkusername?username=' + username;
    return this.http.get(url);
  }

  /**
   *  Update Account User
   * @param acc Application User
   */
  public updateAccountInfomaiton(acc: ApplicationUser) {
    let url: string = this.config.ApiUrl + '/api/Account/users/update';
    return this.http.post(url, acc);
  }

  /**
   *  Update Password
   * @param username Username
   * @param oldPass Old Password
   * @param newPass New Password
   */
  public updatePassword(username: string, oldPass: string, newPass: string) {
    let url: string = this.config.ApiUrl + '/api/Account/password/update';
    return this.http.post(url, {
      username: username,
      oldPassword: oldPass,
      newPassword: newPass
    });
  }

  /** Get Account Types */
  public getAccountTypes() {
    let url: string = this.config.ApiUrl + '/api/Account/types';
    return this.http.get(url);
  }

}
