import { Injectable } from '@angular/core';
import { ApplicationUser } from '../models/application-user.model';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  public static readonly USER_STORE: string = 'CAPITALBET_USERSTORE';
  private static _isInit = false;

  /** Has The Storage Been Initialized */
  public get IsInit(): boolean {
    return LocalStorageService._isInit;
  }

  /** Get the current stored user or null */
  public get CurrentUser(): ApplicationUser {
    let user: ApplicationUser = null;
    let serialObj = sessionStorage.getItem(LocalStorageService.USER_STORE);
    if (serialObj != null) {
      user = JSON.parse(serialObj);
      return user;
    } else
      return null;
  }

  /** Clear the current authentication information */
  public clearAuthentication() {
    sessionStorage.removeItem(LocalStorageService.USER_STORE);
  }


  /**
   * Login The User
   * @param user User Object
   */
  public LoginUser(user: ApplicationUser) {
    sessionStorage.setItem(LocalStorageService.USER_STORE, JSON.stringify(user));
  }


  constructor() {
    this.initializeStorage();
  }


  /** Initialize The Memory load data from local storage */
  public initializeStorage() {
    if (!LocalStorageService._isInit) {



      LocalStorageService._isInit = true;
    }
  }
}
