import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { TabsetComponent, MDBModalRef, MDBModalService } from 'ng-uikit-pro-standard';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TermsAndConditionsComponent } from '../terms-and-conditions/terms-and-conditions.component';
import { RiskStatementComponent } from '../risk-statement/risk-statement.component';
import { AccountType } from '../../models/account-type.model';
import { AccountService } from '../../services/account.service';
import { Subscription } from 'rxjs';
import * as moment from 'moment';
import { ApplicationUser } from '../../models/application-user.model';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit, OnDestroy {
  @ViewChild('staticTabs', { static: true }) staticTabs: TabsetComponent;

  termsDialog: MDBModalRef;
  riskDialog: MDBModalRef;

  progressUpdate: string = 'Processing Account ...';
  totalDeposit: number = 0;
  currentValue: number = 0;
  minRange: number = 0;
  maxRange: number = 9500;
  completeEnabled: boolean = false;
  uiDisabled: boolean = false;

  registerGroup: FormGroup;

  selectedAccount: AccountType = null;

  errorMessage: string = '';

  cards: AccountType[] = [];
  slides: any = [[]];
  private chunk(arr, chunkSize) {
    let R = [];
    for (let i = 0, len = arr.length; i < len; i += chunkSize) {
      R.push(arr.slice(i, i + chunkSize));
    }
    return R;
  }

  subs: Subscription[] = [];

  get RegisterFirstName() { return this.registerGroup.get('fname'); }
  get RegisterLastName() { return this.registerGroup.get('lname'); }
  get RegisterUsername() { return this.registerGroup.get('username'); }
  get RegisterEmail() { return this.registerGroup.get('email'); }
  get RegisterPassword() { return this.registerGroup.get('pass1'); }
  get RegisterConfirmPass() { return this.registerGroup.get('pass2'); }
  get RegisterTerms() { return this.registerGroup.get('terms'); }
  get RegisterOutOfUsa() { return this.registerGroup.get('usaOut'); }



  constructor(private fb: FormBuilder,
    private accSrv: AccountService,
    private auth: AuthService,
    private route:Router,
    private modalSrv: MDBModalService) {
    this.registerGroup = this.fb.group({
      fname: ['', [Validators.required]],
      lname: ['', [Validators.required]],
      username: ['', [Validators.required]],
      email: ['', [Validators.required]],
      pass1: ['', [Validators.required]],
      pass2: ['', [Validators.required]],
      terms: [false],
      usaOut: [false]
    });

  }


  ngOnInit(): void {
    this.slides = this.chunk(this.cards, 3);
    this.subs.push(
      this.accSrv.getAccountTypes().subscribe((result: AccountType[]) => {
        this.cards = result;
        this.slides = this.chunk(this.cards, 3);
      })
    );
  }

  ngOnDestroy(): void {
    for (let itm of this.subs) {
      itm.unsubscribe();
    }
  }

  showTerms() {
    this.termsDialog = this.modalSrv.show(TermsAndConditionsComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-lg',
      containerClass: '',
      animated: true
    });
  }


  showRiskStatement() {
    this.riskDialog = this.modalSrv.show(RiskStatementComponent, {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-lg',
      containerClass: '',
      animated: true
    })
  }


  rangeChanged(result) {
    this.currentValue = result.value;
    this.totalDeposit = this.currentValue + (this.currentValue * this.selectedAccount.bouns);
  }

  parseDate(timespan) {
    var tm = timespan / 86400000;
    return (tm > 1) ? tm + ' Days' : '1 Day';
  }

  registerUserInfo() {
    this.errorMessage = '';
    if (this.registerGroup.valid) {

      if (!this.RegisterTerms.value) {
        this.errorMessage += 'Please review and accept the Terms and Risk Statements to continue ...<br/>';
      }

      if (!this.RegisterOutOfUsa.value) {
        this.errorMessage += 'Only accounts outside of the USA and their territories can be added ...<br/>';
      }

      if (this.RegisterPassword.value != this.RegisterConfirmPass.value) {
        this.errorMessage += 'The password fields do not match ...<br/>';
      }


      if (this.errorMessage.length == 0)
        this.staticTabs.setActiveTab(2);
    } else {

      if (this.RegisterFirstName.invalid)
        this.errorMessage += 'First Name is required ...<br/>';
      if (this.RegisterLastName.invalid)
        this.errorMessage += 'Last Name is required ...<br/>';
      if (this.RegisterUsername.invalid)
        this.errorMessage += 'Username is required ...<br/>';
      if (this.RegisterEmail.invalid)
        this.errorMessage += 'Email Address is required ...<br/>';
      if (this.RegisterPassword.invalid)
        this.errorMessage += 'Password is required ...<br/>';
      if (this.RegisterConfirmPass.invalid)
        this.errorMessage += 'Please confirm your password ...<br/>';
      console.log(this.errorMessage);
    }
  }


  signUpAccount(id: string) {
    var obj = this.cards.filter(v => v.typeId == id);
    if (obj.length > 0) {
      this.selectedAccount = obj[0];
      this.minRange = this.selectedAccount.minimumDeposit;
      this.currentValue = this.minRange;
    }
    this.completeEnabled = true;
    this.staticTabs.setActiveTab(3);
  }

  fundsLastStep() {
    this.completeEnabled = false;
    this.staticTabs.setActiveTab(2);
  }

  fundsNextStep() {
    this.staticTabs.setActiveTab(4);
  }


  completeAccountAction() {
    this.uiDisabled = true;

    let usr: ApplicationUser = new ApplicationUser();
    usr.email = this.RegisterEmail.value;
    usr.isEnabled = true;
    usr.firstName = this.RegisterFirstName.value;
    usr.lastName = this.RegisterLastName.value;
    usr.userName = this.RegisterUsername.value;

    this.subs.push(
      this.accSrv.registerUser(usr, this.RegisterPassword.value, this.currentValue, this.selectedAccount.typeId).subscribe((user: ApplicationUser) => {
        if (user != null) {
          this.auth.signIn(this.RegisterUsername.value, this.RegisterPassword.value, false).subscribe(() => {
            this.route.navigateByUrl("/home/index");
          }, err => {
              this.uiDisabled = false;
              this.errorMessage = 'Failed to authenticate the new user record ...<br/>';
          })
        }
      }, err => {
          this.uiDisabled = false;
          this.errorMessage = 'Failed to register the new user record ...<br/>';
      })
    );
  }

}
