import { Component, OnInit, OnDestroy } from '@angular/core';
import { ConfigService } from '../../services/config.service';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';
import { MDBModalService, MDBModalRef } from 'ng-uikit-pro-standard';
import { LoginFormComponent } from '../login-form/login-form.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit, OnDestroy {


  loginDialog: MDBModalRef;

  isAuthed: boolean = false;
  twitterUrl: string = 'https://www.twitter.com';
  facebookUrl: string = 'https://www.facebook.com';


  subs: Subscription[] = [];

  constructor(private conf: ConfigService,
    private modalSrv: MDBModalService,
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
      ignoreBackdropClick: false,
      class: 'modal-side modal-top-right',
      containerClass: 'right',
      animated: true
    });
  }

}
