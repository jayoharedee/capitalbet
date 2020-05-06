import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SharedModule } from '../shared.module';
import { HowItWorksComponent } from './how-it-works/how-it-works.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { IndexComponent } from './index/index.component';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { TermsAndConditionsComponent } from './terms-and-conditions/terms-and-conditions.component';
import { RiskStatementComponent } from './risk-statement/risk-statement.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptor } from '../services/token-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';


@NgModule({
  declarations: [
    HomeComponent,
    HowItWorksComponent,
    SignUpComponent,
    IndexComponent,
    TermsAndConditionsComponent,
    RiskStatementComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule.forRoot(),
    MDBBootstrapModulesPro.forRoot(),
    HomeRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  entryComponents: [
    TermsAndConditionsComponent,
    RiskStatementComponent
  ]
})
export class HomeModule { }
