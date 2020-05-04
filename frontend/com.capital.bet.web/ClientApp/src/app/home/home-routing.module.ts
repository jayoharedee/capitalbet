import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';
import { IndexComponent } from './index/index.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { HowItWorksComponent } from './how-it-works/how-it-works.component';
import { PathNotFoundComponent } from '../shared/path-not-found/path-not-found.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      { path: 'index', component: IndexComponent },
      { path: 'signup', component: SignUpComponent },
      { path: 'howitworks', component: HowItWorksComponent },
      { path: '', redirectTo: 'index', pathMatch: 'full' },
      { path: '**', component: PathNotFoundComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
