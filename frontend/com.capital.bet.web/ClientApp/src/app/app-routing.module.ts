import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PathNotFoundComponent } from './shared/path-not-found/path-not-found.component';


const routes: Routes = [
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
  { path: 'markets', loadChildren: () => import('./markets/markets.module').then(m => m.MarketsModule) },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'support', loadChildren: () => import('./support/support.module').then(m => m.SupportModule) },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: '**', component: PathNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
