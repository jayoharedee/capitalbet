
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OAuthService, OAuthErrorEvent } from 'angular-oauth2-oidc';
import { ConfigService } from './config.service';
import { JwtHelper } from './jwt-helper';
import { Observable, Subject, from, throwError } from 'rxjs';
import { map, mergeMap, filter, catchError, tap, take } from 'rxjs/operators';
import { LocalStorageService } from './local-storage.service';
import { AccountService } from './account.service';
import { ApplicationUser } from '../models/application-user.model';
import { AccessToken } from '../models/access-token.model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly _discoveryDocUrl: string = '/.well-known/openid-configuration';

  private get discoveryDocUrl() { return this.config.AuthenticationServer + this._discoveryDocUrl; }


  public loginRedirectUrl: string;
  public logoutRedirectUrl: string;

  public reLoginDelegate: () => void;

  private previousIsLoggedInCheck = false;
  private _loginStatus: Subject<boolean> = new Subject();
  private _userUpdated: Subject<ApplicationUser> = new Subject();
  private _currentUser: ApplicationUser = null;

  /** Update User Status */
  get UpdateUserStatus(): Observable<ApplicationUser> {
    return this._userUpdated.asObservable();
  }

  constructor(private http: HttpClient,
    private config: ConfigService,
    private accSrv: AccountService,
    private store: LocalStorageService,
    private oauth: OAuthService) {

    // make sure we have initialized the application storage
    if (!this.store.IsInit)
      this.store.initializeStorage();

    // get current user from application storage
    this._currentUser = this.store.CurrentUser;
    this.reevaluateLogin();
  }

  private initializeOdicService() {
    this.oauth.issuer = 'http://localhost:5000';
    this.oauth.clientId = 'capitalbet_spa';
    this.oauth.scope = 'openid email phone profile offline_access capitalbet_api';
    this.oauth.skipSubjectCheck = true;
    this.oauth.dummyClientSecret = 'not_used';
    this.oauth.setStorage(sessionStorage);
  }

  /** Is the User Logged In */
  public isLoggedInStatus(): Observable<boolean> {
    return this._loginStatus.asObservable();
  }

  /** is Logged In */
  public get isLoggedIn(): boolean {
    return (this._currentUser == null) ? false : true;
  }

  /** The Current Application User Subject */
  public get currentUser(): ApplicationUser {
    if (this._currentUser == null) {
      this._currentUser = this.store.CurrentUser;
      this.reevaluateLogin();
    }
    return this._currentUser;
  }

  /** The Current Auth Token Expiry */
  public get accessTokenExpiryDate(): Date {
    return new Date(this.oauth.getAccessTokenExpiration());
  }

  /** Get Current Access Token */
  public get AccessToken(): string {
    return this.oauth.getAccessToken();
  }

  /** Is Session Expired */
  public get isSessionExpired(): boolean {
    if (this.accessTokenExpiryDate == null) {
      return true;
    }
    return this.accessTokenExpiryDate.valueOf() <= new Date().valueOf();
  }

  /** Get Refresh Token */
  public get refreshToken(): string {
    return this.oauth.getRefreshToken();
  }

  /**
   * Sign User In
   * @param username username
   * @param password Password
   * @param rememberMe rememberer user?
   */
  public signIn(username: string, password: string, rememberMe?: boolean) {
    if (this.isLoggedIn) {
      this.signOut();
    }
    this.initializeOdicService();

    return from(this.oauth.loadDiscoveryDocument(this.discoveryDocUrl)).pipe(
      mergeMap(() => {
        return from(this.oauth.fetchTokenUsingPasswordFlow(username, password)).pipe(
          map(() => this.processLoginResponse(this.oauth.getAccessToken(), rememberMe))
        );
      }));
  }

  /** Refresh Login */
  public refreshLogin(): Observable<ApplicationUser> {
    if (this.oauth.discoveryDocumentLoaded) {
      return from(this.oauth.refreshToken()).pipe(
        map(() => this.processLoginResponse(this.oauth.getAccessToken(), false)));
    } else {
      this.initializeOdicService();
      return from(this.oauth.loadDiscoveryDocument(this.discoveryDocUrl)).pipe(mergeMap(() => this.refreshLogin()));
    }
  }

  private processLoginResponse(accessToken: string, rememberMe: boolean) {
    if (accessToken == null) {
      throw new Error('accessToken cannot be null');
    }

    const jwtHelper = new JwtHelper();
    const decodedAccessToken = jwtHelper.decodeToken(accessToken) as AccessToken;
    const user = new ApplicationUser();

    // load the profile from the service
    this.oauth.loadUserProfile().then((val: any) => {
      user.email = val.email;
      user.emailConfirmed = val.email_verified;
      user.id = val.sub;
      user.userName = val.name;
      this.store.LoginUser(user);
      this._loginStatus.next(true);
      this._userUpdated.next(user);

      this.accSrv.getCurrentUser().pipe(
        take(1)
      ).subscribe((usr: ApplicationUser) => {
        this.store.LoginUser(usr);
        this._currentUser = usr;
        this._loginStatus.next(true);
        this._userUpdated.next(usr);
      });
      return user;
    });
    return user;
  }

  /** Sign Out  */
  public signOut() {
    if (this.isLoggedIn) {
      this._currentUser = null;
      this.store.clearAuthentication();
      this.oauth.logOut();
      this._loginStatus.next(false);
    }
  }

  private reevaluateLogin() {
    const user = this._currentUser;
    const isLoggedIn = user != null;
    if (this.previousIsLoggedInCheck != isLoggedIn) {
      setTimeout(() => {
        this._loginStatus.next(isLoggedIn);
      });
    }
    this.previousIsLoggedInCheck = isLoggedIn;
  }


}
