import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { MDBSpinningPreloader } from 'ng-uikit-pro-standard';
import { AuthService } from './services/auth.service';
import { ConfigService } from './services/config.service';
import { AccountService } from './services/account.service';
import { LocalStorageService } from './services/local-storage.service';
import { AuthGuardService } from './services/auth-guard.service';
import { PathNotFoundComponent } from './shared/path-not-found/path-not-found.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { FooterComponent } from './shared/footer/footer.component';
import { LoginFormComponent } from './shared/login-form/login-form.component';
import { EscapeHtmlPipe } from './pipes/keep-html.pipe';
import { StocksService } from './services/stocks.service';
import { ErrorDialogComponent } from './shared/error-dialog/error-dialog.component';
import { ErrorDialogService } from './services/error-dialog.service';



@NgModule({
  declarations: [
    EscapeHtmlPipe,
    PathNotFoundComponent,
    NavMenuComponent,
    FooterComponent,
    LoginFormComponent,
    ErrorDialogComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MDBBootstrapModulesPro,
  ],
  exports: [
    EscapeHtmlPipe,
    NavMenuComponent,
    FooterComponent,
    LoginFormComponent
  ],
  entryComponents: [
    LoginFormComponent,
    ErrorDialogComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        AuthService,
        ConfigService,
        AccountService,
        ErrorDialogService,
        LocalStorageService,
        AuthGuardService,
        StocksService,
        MDBSpinningPreloader,
      ]
    };
  }
}
