import { Component, OnInit, OnDestroy } from '@angular/core';
import { ConfigService } from '../../services/config.service';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';
import { MDBModalService, MDBModalRef } from 'ng-uikit-pro-standard';
import { LoginFormComponent } from '../login-form/login-form.component';
import {
  Event,
  NavigationCancel,
  NavigationEnd,
  NavigationError,
  NavigationStart,
  Router
} from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit, OnDestroy {

  showProgressBar: boolean = false;
  loginDialog: MDBModalRef;

  isAuthed: boolean = false;
  twitterUrl: string = 'https://www.twitter.com';
  facebookUrl: string = 'https://www.facebook.com';


  subs: Subscription[] = [];

  constructor(private conf: ConfigService,
    private modalSrv: MDBModalService,
    private router: Router,
    private auth: AuthService) { }
    

  ngOnInit(): void {
    this.subs = [];

    this.twitterUrl = this.conf.TwitterUrl;
    this.facebookUrl = this.conf.FacebookUrl;

    this.subs.push(
      this.auth.isLoggedInStatus().subscribe((loggedIn: boolean) => {
        this.isAuthed = loggedIn;
      })
    );

    this.subs.push(
    this.router.events.subscribe((event: Event) => {
      switch (true) {
        case event instanceof NavigationStart: {
          this.showProgressBar = true;
          break;
        }

        case event instanceof NavigationEnd:
        case event instanceof NavigationCancel:
        case event instanceof NavigationError: {
          this.showProgressBar = false;
          break;
        }
        default: {
          break;
        }
      }
    }));
  }

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }


  openSignInDialog() {
    this.loginDialog = this.modalSrv.show(LoginFormComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true
    });
  }


  signOutAction() {
    this.auth.signOut();
    this.router.navigateByUrl('/home/index');
  }

}
