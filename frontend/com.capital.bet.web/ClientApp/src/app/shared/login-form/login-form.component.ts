import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MDBModalRef } from 'ng-uikit-pro-standard';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit, OnDestroy {

  errorMessage: string = '';
  loginGroup: FormGroup;
  processingLogin: boolean = false;


  get UserName() { return this.loginGroup.get('username'); }
  get Password() { return this.loginGroup.get('password'); }
  get RememeberMe() { return this.loginGroup.get('rememberMe'); }

  subs: Subscription[] = [];

  constructor(private fb: FormBuilder,
    private auth: AuthService,
    public mdbRef: MDBModalRef)
  {
    this.loginGroup = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
      rememberMe:[false]
    })
  }
    

  ngOnInit(): void {
    this.subs = [];
    this.subs.push(
      this.auth.isLoggedInStatus().subscribe(val => {
        if (val)
          this.mdbRef.hide();
      })
    );
  }

  ngOnDestroy(): void {
    for (let i of this.subs) {
      i.unsubscribe();
    }
  }


  signOnUser() {
    this.errorMessage = '';
    this.processingLogin = true;
    if (this.loginGroup.valid) {
      this.subs.push(
        this.auth.signIn(this.UserName.value, this.Password.value, this.RememeberMe.value).subscribe(() => {
          this.processingLogin = false;
        }, err => {
            this.processingLogin = false;
            this.errorMessage = 'The system was unable to validate the supplied user credentials ...<br/>';
        })
      );
    } else {
      this.processingLogin = false;
      if (this.UserName.invalid)
        this.errorMessage += 'Please provide a valid username ...<br/>';
      if (this.Password.invalid)
        this.errorMessage += 'Please provide a valid password ...<br/>';
    }
  }

}
