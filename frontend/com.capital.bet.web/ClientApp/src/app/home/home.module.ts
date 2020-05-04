import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SharedModule } from '../shared.module';
import { HowItWorksComponent } from './how-it-works/how-it-works.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { IndexComponent } from './index/index.component';


@NgModule({
  declarations: [
    HomeComponent,
    HowItWorksComponent,
    SignUpComponent,
    IndexComponent
  ],
  imports: [
    CommonModule,
    SharedModule.forRoot(),
    HomeRoutingModule
  ]
})
export class HomeModule { }
